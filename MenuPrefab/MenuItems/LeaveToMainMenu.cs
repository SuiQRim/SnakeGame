using SnakeGame.MenuPrefab;
using SnakeGame.Game;
using SnakeGame.GameData.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaveToMainMenu : AMenuElement
    {
        public LeaveToMainMenu(Player player, ScoreObserver scoreObserver) : base(player, scoreObserver, "Выйти в главное меню")
        {

        }
        public override Menu Do()
        {
            return new MainMenu(_player);
        }
    }
}
