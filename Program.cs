using SnakeGame;
using SnakeGame.Skins;

Console.SetWindowSize(50,25);
Console.CursorVisible = false;
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;


View view = new();
Scene scene = new(15,15, new Snake(new DefaultSkin(),15,15), view);

