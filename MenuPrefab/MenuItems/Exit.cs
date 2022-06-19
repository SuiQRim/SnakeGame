using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Exit : AMenuElement
    {
        public Exit(Player player, IScore scoreObserver ) : base (player, scoreObserver , "Выйти") { }

        public override Menu Do()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
