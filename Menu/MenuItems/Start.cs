using SnakeGame.SnakePrefab;
using SnakeGame.Game;

namespace SnakeGame.Menu.MenuItems
{
    internal class Start : MenuElement
    {
        public Start() : base ("Начать")  { 
        }
        public override void Do()
        {
            Scene scene = new(15, 15, new Snake(new DefaultSkin(), 15, 15));
            scene.StartSprint();
        }
    }
}
