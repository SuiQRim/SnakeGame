using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SnakeGame.Orintation;

namespace SnakeGame.SnakePrefab
{
    internal abstract class Segment
    {
        public Segment(Position position, char view)
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

        protected Direction _lastDirrection;

        public void Grow() 
        {
            if (_childSegment == null)
            {
                _childSegment = new Body(new Position(_position));
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
                _childSegment.Move(_lastDirrection);
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

        private readonly char _view;
        public override string ToString()
        {
            return _view.ToString();
        }

    }
}
