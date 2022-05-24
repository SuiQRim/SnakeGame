using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.MenuPrefab;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaveToMainMenu : AMenuElement
    {
        public LeaveToMainMenu(Player player) : base ( player,"Выйти в главное меню")
        {

        }
        public override Menu Do()
        {
            return new MainMenu(_player);
        }
    }
}
