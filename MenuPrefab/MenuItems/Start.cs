using SnakeGame.SnakePrefab;
using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Start : AMenuElement
    {
        public Start(Player player, IScore scoreObserver) : base(player, scoreObserver, "Старт")  { }

        public override Menu Do()
        {
            Scene scene = new(16, 16, _player);
            scene.Start();

            _scoreObserver.SaveGameResult(scene.GameResult);

            return new EndGameMenu(_player, scene.GameResult, _scoreObserver);
        }
    }
}
