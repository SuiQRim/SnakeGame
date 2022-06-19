using SnakeGame.Game;
using SnakeGame.GameData;
using SnakeGame.GameData.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class RestartGame : AMenuElement
    {
        public RestartGame(Player player, ScoreObserver scoreObserver) : base(player, scoreObserver, "Играть снова")
        {
           
        }
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
