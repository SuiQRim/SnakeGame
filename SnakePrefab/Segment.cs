using SnakeGame.Binding;
using SnakeGame.Game;

namespace SnakeGame.SnakePrefab
{
    internal abstract class Segment
    {
        public Segment(Position position, string view)
        {
            _view = view;
            _position = position;

        }

        private Position _position;
        public Position Position
        {
            get => _position;
            protected set => _position = value;
        }

        private Position _lastPosition;
        public Position LastPosition
        {
            get => _lastPosition;
            protected set => _lastPosition = value;
        }

        protected Direction _lastDirrection;

        public void Grow() 
        {
            if (_childSegment == null)
            {
                _childSegment = new Body(new Position(_position), LastPosition);
            }
            else
            {
                _childSegment.Grow();
            }
        }

        protected void MoveLogic(Direction direction) 
        {
         
            switch (direction)
            {
                case UpWard:
                    Position.PosY--;
                    break;
                case DownWard:
                    Position.PosY++;
                    break;
                case RightWard:
                    Position.PosX++;
                    break;
                case LeftWard:
                    Position.PosX--;
                    break;
            }

            if (_childSegment != null)
            {
                _childSegment.Move(_lastDirrection, Position);
            }
            _lastDirrection = direction;
        }

        protected Body _childSegment;

        public List<Segment> AddToListOfSegment(List<Segment> segmentList) 
        {
            segmentList.Add(this);

            if (_childSegment != null)
            {
                _childSegment.AddToListOfSegment(segmentList);
            }

            return segmentList;
        }

        private readonly string _view;
        public override string ToString()
        {
            return _view;
        }

    }
}
