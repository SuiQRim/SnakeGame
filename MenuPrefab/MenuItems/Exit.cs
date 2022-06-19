using SnakeGame.Game;
using SnakeGame.GameData.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Exit : AMenuElement
    {
        public Exit(Player player, ScoreObserver scoreObserver ) : base (player, scoreObserver , "Выйти") { }

        public override Menu Do()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
