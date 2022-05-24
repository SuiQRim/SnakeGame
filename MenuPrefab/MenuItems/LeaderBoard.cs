using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaderBoard : AMenuElement
    {
        public LeaderBoard() : base ("Таблица лидеров")
        {

        }

        public override Menu Do()
        {
            return new MainMenu();
        }
    }
}
