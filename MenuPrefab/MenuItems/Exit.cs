using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Exit : MenuElement
    {
        public Exit() : base ("Выйти") { }

        public override Menu Do()
        {
            return new MainMenu();
        }
    }
}
