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

        public Head(Position position) : base(position, '@')
        {
            _moveController = new();
        }


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
        }
    }
}
