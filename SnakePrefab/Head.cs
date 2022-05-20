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
        public Head(Position position)
        {
            this.Position = position;
            _moveController = new();
            new Thread(() => _moveController.ReadAllKey()).Start();
        }

        private Direction _lastDirrection;
        private Direction _blockedDirrection = new LeftWard();

        private DirectionController _moveController;
        public DirectionController MoveController
        {
            get { return _moveController; }
        }

        public override void Move()
        {
            Direction direction = _moveController.Direction;

            if (_moveController.Direction.GetType() == _blockedDirrection.GetType())
            {
                direction = _lastDirrection;
            }
            //BodyMap[_headPosition.PosY - 1, _headPosition.PosX - 1] = Skin.SideDecoration;
            switch (direction)
            {
                case UpWard:
                    Position.PosY--;
                    _blockedDirrection = new DownWard();
                    break;
                case DownWard:
                    Position.PosY++;
                    _blockedDirrection = new UpWard();
                    break;
                case RightWard:
                    Position.PosX++;
                    _blockedDirrection = new LeftWard();
                    break;
                case LeftWard:
                    Position.PosX--;
                    _blockedDirrection = new RightWard();
                    break;
            }
            _lastDirrection = direction;
        }
    }
}
