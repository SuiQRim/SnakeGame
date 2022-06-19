using SnakeGame.SnakePrefab;
using SnakeGame.Game;
using SnakeGame.GameData;
using SnakeGame.GameData.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Start : AMenuElement
    {
        public Start(Player player, ScoreObserver scoreObserver) : base(player, scoreObserver, "Старт")  { }

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
