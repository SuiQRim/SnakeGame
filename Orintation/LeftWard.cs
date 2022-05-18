using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Orintation
{
    internal class LeftWard : Direction
    {
        public LeftWard() : base("Влево", ConsoleKey.LeftArrow)
        {

        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
