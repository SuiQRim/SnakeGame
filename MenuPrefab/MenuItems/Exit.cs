using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class Exit : AMenuElement
    {
        public Exit(Player player ) : base (player, "Выйти") { }

        public override Menu Do()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
