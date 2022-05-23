using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.MenuPrefab.MenuItems;

namespace SnakeGame.MenuPrefab
{
    internal class EndGameMenu : Menu
    {
        public EndGameMenu() : base()
        {
            _menuElements = new()
            {
                new RestartGame(),
                new LeaveToMainMenu()
            };
        }

    }
}
