using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal abstract class Direction
    {
        public Direction(string orintation, ConsoleKey key) 
        { 
            OrintationName = orintation;
            HotKey = key;
        }

        public string OrintationName { get; set; }
        private ConsoleKey HotKey { get; set; }

        const char active = '▓';
        const char notActive= '░';
        public abstract string Print();
    }
}
