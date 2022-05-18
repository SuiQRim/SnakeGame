using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Orintation
{
    internal class UpWard : Direction
    {
        public UpWard() : base ("Вверх", ConsoleKey.UpArrow)
        {

        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
