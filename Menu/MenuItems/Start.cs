using SnakeGame.SnakePrefab;
using SnakeGame.Game;

namespace SnakeGame.Menu.MenuItems
{
    internal class Start : MenuElement
    {
        public Start() : base ("Старт")  { }

        public override void Do()
        {
            Scene scene = new(15, 15, new Snake( 15, 15));
            scene.StartSprint();
        }
    }
}
