using SnakeGame;
Console.OutputEncoding = System.Text.Encoding.UTF8;

View view = new ();
MoveController controller = new ();

new Thread(() => controller.ReadAllKeyAcync()).Start();
 

Scene scene = new(25,25, new Snake(), view);

