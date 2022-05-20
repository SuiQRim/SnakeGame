using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;

namespace SnakeGame
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

        public static Direction GetReverseOrintation(Direction direction) 
        {
            switch (direction) 
            {
                case UpWard: return new DownWard();
                case DownWard: return new UpWard();
                case RightWard: return new LeftWard();
                case LeftWard: return new RightWard();
                default: throw new ArgumentNullException();
            }
             
        }
        public abstract string Print();
    }
}
