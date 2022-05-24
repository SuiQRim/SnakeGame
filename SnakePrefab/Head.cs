using SnakeGame.Binding;
using SnakeGame.Game;

namespace SnakeGame.SnakePrefab
{
    internal class Head : Segment
    {

        public Head(Position position, Snake snake) : base(position, "██")
        {
            _moveController = new();
            HeadCrash += snake.Die;
            _childSegment = new Body(new Position(position), position);
        }

        private event Action HeadCrash;

        private Direction _blockedDirrection = new LeftWard();

        private readonly DirectionController _moveController;
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
                if (isCrash) HeadCrash?.Invoke();
            }
        }
    }
}
