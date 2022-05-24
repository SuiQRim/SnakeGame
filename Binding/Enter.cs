using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Binding
{
    internal class Enter : Direction
    {
        public Enter() : base("Принять")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.Enter
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
