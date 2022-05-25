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
            Scene scene = new(16, 16, _player);
            scene.Start();

            Observer observer = new();
            observer.SetGameResult(scene.GameResult);

            return new EndGameMenu(_player, scene.GameResult);
        }
    }
}
