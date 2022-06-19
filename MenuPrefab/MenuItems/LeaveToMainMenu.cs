using SnakeGame.MenuPrefab;
using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaveToMainMenu : AMenuElement
    {
        public LeaveToMainMenu(Player player, IScore scoreObserver) : base(player, scoreObserver, "Выйти в главное меню")
        {

        }
        public override Menu Do()
        {
            return new MainMenu(_player, _scoreObserver);
        }
    }
}
