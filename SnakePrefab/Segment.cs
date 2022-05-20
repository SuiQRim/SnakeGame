using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.SnakePrefab
{
    internal abstract class Segment
    {
        private Position _position;
        public Position Position
        {
            get => _position;
            protected set => _position = value;
        }

        public abstract void Move();

        private static readonly char _view;
        public override string ToString()
        {
            return _view.ToString();
        }
    }
}
