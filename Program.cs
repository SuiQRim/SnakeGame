using SnakeGame;

Scene scene = new(25,25, new SnakeGame.Snake());

View view = new ();

view.WriteMap(scene);
