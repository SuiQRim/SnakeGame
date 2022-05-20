using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Point
    {
        public Point(Position position)
        {
            _position = position;
        }

        private Position _position;
    }
}
