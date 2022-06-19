using SnakeGame.DataBase;
using SnakeGame.DataBase.Score;
using SnakeGame.MenuPrefab;
using SnakeGame.Game;
using System.Text.Json;
using SnakeGame;

Console.SetWindowSize(100, 50);
Console.CursorVisible = false;
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;

SnakeDBContext snakeDB = new();
ScoreObserver scoreObserver = new GlobalDB();

if (!snakeDB.Database.Exists())
{
    Console.ForegroundColor = ConsoleColor.Red;
    scoreObserver = new LocalDB();
    List<string> serverStatus = new List<string>() { "Сервер не найден", "Включен автономный режим" };
    View.WriteMenuInfoWindow(serverStatus, ConsoleColor.Red);

}
Console.ForegroundColor = ConsoleColor.White;
string text = "Введите никнейм";
Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2 - 2);
Console.Write(text);
Console.ForegroundColor = ConsoleColor.Blue;
Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
string nickName = Console.ReadLine();

Player player = new Player(nickName, nickName);
 
string jsonPlayers = File.ReadAllText("Players.json");
List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonPlayers).ToList();

if (!players.Exists(s => s.NickName == player.NickName))
{
    players.Add(player);
    File.WriteAllText("Players.json", JsonSerializer.Serialize(players));
}

scoreObserver.OnConfigurate(player);


MainMenu menu = new (player, scoreObserver);
menu.Start();

