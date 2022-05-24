using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class PlayerProfil : AMenuElement
    {
        public PlayerProfil(Player player) : base (player, "Профиль")
        {

        }

        public override Menu Do()
        {
            return new MainMenu(_player);
        }
    }
}
