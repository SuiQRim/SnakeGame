using SnakeGame.DataBase;
using SnakeGame.MenuPrefab;
using SnakeGame.Game;
using SnakeGame;

Console.SetWindowSize(100, 50);
Console.CursorVisible = false;
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;

SnakeDBContext snakeDB = new();
Observer observer = new GlobalDB();

if (!snakeDB.Database.Exists())
{
    observer = new LocalDB();
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

Player player = new (nickName);
 
if (!observer.PlayerExists(player))
{
    observer.AddPlayer(player);
}

observer.OnConfigurate(player);
MainMenu menu = new (player, observer);
menu.Start();

