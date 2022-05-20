using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.SnakePrefab
{
    internal class Body : Segment
    {
        public Body(Position position) : base(position)
        {

        }
        private bool _isCreated = true;

        public void Move(Direction direction)
        {
            if (_isCreated) { 
            
                _isCreated = false;
                return;
            }

            MoveLogic(direction);

        }
    }
}
