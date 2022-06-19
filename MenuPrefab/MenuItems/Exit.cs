using SnakeGame.Game;
using SnakeGame.DataBase.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Exit : AMenuElement
    {
        public Exit(Player player, IScoreController scoreObserver ) : base (player, scoreObserver , "Выйти") { }

        public override Menu Do()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
