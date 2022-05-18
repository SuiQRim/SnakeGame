using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Orintation
{
    internal class DownWard : Direction
    {
        public DownWard() : base("Вниз", ConsoleKey.DownArrow)
        {

        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
