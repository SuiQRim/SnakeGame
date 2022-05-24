using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class RestartGame : AMenuElement
    {
        public RestartGame() : base("Играть снова")
        {
           
        }
        public override Menu Do()
        {
            Scene scene = new(15, 15, new Snake(15, 15));
            scene.Start();

            return new EndGameMenu();
        }
    }
}
