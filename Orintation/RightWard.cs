using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Orintation
{
    internal class RightWard : Direction
    {
        public RightWard() : base("Вправо", ConsoleKey.RightArrow)
        {

        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
