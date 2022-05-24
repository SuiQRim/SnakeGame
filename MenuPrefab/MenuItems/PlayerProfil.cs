using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class PlayerProfil : AMenuElement
    {
        public PlayerProfil() : base ("Профиль")
        {

        }

        public override Menu Do()
        {
            return new MainMenu();
        }
    }
}
