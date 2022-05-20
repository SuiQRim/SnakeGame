using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;

namespace SnakeGame.SnakePrefab
{
    internal class Head : Segment
    {

        public Head(Position position, Snake snake) : base(position, '@')
        {
            _moveController = new();
            _HeadCrash += snake.Die;
        }

        private event Action _HeadCrash;

        private Direction _blockedDirrection = new LeftWard();

        private DirectionController _moveController;
        public DirectionController MoveController
        {
            get { return _moveController; }
        }

        public void Move()
        {
            Direction direction = _moveController.Direction;
          
            if (_moveController.Direction.GetType() == _blockedDirrection.GetType())
            {
                direction = _lastDirrection;
            }

            MoveLogic(direction);

            _blockedDirrection = Direction.GetReverseOrintation(direction);

            if (_childSegment != null)
            {
                bool isCrash = _childSegment.CheckHeadCrashed(Position);
                if (isCrash) _HeadCrash?.Invoke();
            }
        }
    }
}
