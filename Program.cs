using SnakeGame;
using SnakeGame.Skins;

Console.OutputEncoding = System.Text.Encoding.UTF8;

View view = new ();
Scene scene = new(25,25, new Snake(new DefaultSkin()), view);

