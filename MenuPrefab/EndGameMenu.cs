using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab
{
    internal class EndGameMenu : Menu
    {
        public EndGameMenu(Player player) : base(player)
        {
            _menuElements = new()
            {
                new RestartGame(player),
                new LeaveToMainMenu(player)
            };
        }

    }
}
