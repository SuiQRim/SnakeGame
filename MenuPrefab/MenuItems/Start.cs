using SnakeGame.SnakePrefab;
using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Start : AMenuElement
    {
        public Start(Player player) : base (player, "Старт")  { }

        public override Menu Do()
        {
            Scene scene = new(15, 15, _player, new Snake( 15, 15));
            scene.Start();

            Observer observer = new();
            observer.SetGameResult(scene.GameResult);

            return new EndGameMenu(_player, scene.GameResult);
        }
    }
}
