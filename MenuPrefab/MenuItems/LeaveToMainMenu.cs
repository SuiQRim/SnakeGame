using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.MenuPrefab;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaveToMainMenu : MenuElement
    {
        public LeaveToMainMenu() : base ("Выйти в главное меню")
        {

        }
        public override Menu Do()
        {
            return new MainMenu();
        }
    }
}
