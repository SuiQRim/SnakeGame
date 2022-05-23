using SnakeGame.MenuPrefab;

Console.SetWindowSize(50,25);
Console.CursorVisible = false;
Console.Title = "Змейка";
Console.OutputEncoding = System.Text.Encoding.UTF8;

MainMenu menu = new ();
menu.Start();

