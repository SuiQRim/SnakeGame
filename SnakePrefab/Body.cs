using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.SnakePrefab
{
    internal class Body : Segment
    {
        public Body(Position position, Position lastPosition) : base(position, "██")
        {
            LastPosition = lastPosition;
        }

        private bool _isCreated = true;

        public bool CheckHeadCrashed(Position headPos) 
        {
            bool isCrashed = false;
            if (headPos == this.Position) 
            {
                return true;
            }

            if (_childSegment != null)
            {
                isCrashed = _childSegment.CheckHeadCrashed(headPos);
            }
                 
            return isCrashed;
        }

        public void Move(Direction direction, Position headPos)
        {
            LastPosition = new(Position);
            if (_isCreated) { 
            
                _isCreated = false;
                return;
            }

            MoveLogic(direction);

            if (_childSegment != null)
            {
                _childSegment.CheckHeadCrashed(headPos);
            }
        }
    }
}
