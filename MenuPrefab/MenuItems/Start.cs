using SnakeGame.SnakePrefab;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Start : AMenuElement
    {
        public Start() : base ("Старт")  { }

        public override Menu Do()
        {
            Scene scene = new(15, 15, new Snake( 15, 15));
            scene.Start();

            return new EndGameMenu();
        }
    }
}
