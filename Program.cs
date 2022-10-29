using SnakeGame.DataBase;
using SnakeGame.MenuPrefab;
using SnakeGame.Game;
using SnakeGame;

Console.SetWindowSize(60, 30);
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;

Observer storage = new LocalStorage();


Console.ForegroundColor = ConsoleColor.White;
string text = "Введите никнейм";
Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2 - 2);
Console.Write(text);
Console.ForegroundColor = ConsoleColor.Blue;
Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
string nickName = Console.ReadLine();

Player player = new (nickName);
 
if (!storage.PlayerExists(player))
{
    storage.AddPlayer(player);
}
Console.CursorVisible = false;

storage.OnConfigurate(player);
MainMenu menu = new (player, storage);
menu.Start();

