using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.SnakePrefab;

namespace SnakeGame
{
    internal class Scene
    {
        private const int SLEEP = 150;

        public Scene(int width, int heigh, Snake snake)
        {
            _snake = snake;

            _mapSize = new Position(width, heigh);

            MapUpData += View.WriteMap;
            SnakeUpData += View.WriteSnake;

            StartSprint();
            MapUpData?.Invoke( _point, _mapSize);
        }

        private Snake _snake;
        private Point _point;

        private bool _isPointExist = false;

        private Position _mapSize;

        private TimeSpan _roundTime;

        private event Action<Point, Position> MapUpData;

        private event Action<List<Segment>> SnakeUpData;

        public void StartSprint() 
        {
            DateTime start = DateTime.Now;

            SpawnPoint();
            while (_snake.IsAlive)
            {
                _snake.Move();
                CheckCollision();
                if (!_isPointExist)
                {
                    SpawnPoint();
                }
                 
                MapUpData?.Invoke(_point, _mapSize);
                SnakeUpData?.Invoke(_snake.BodyList);
                
                Thread.Sleep(SLEEP);
            }
            DateTime end = DateTime.Now;

            _roundTime = end - start;
        }

        private static readonly Random random = new();

        private void SpawnPoint() 
        {
            if (_isPointExist == false)
            {
                Position pos = Point.SearchClearPosition(_snake.BodyList, _mapSize);

                _point = new(new Position(pos));
                _isPointExist = true;
            }
        }

        private void CheckCollision() 
        {
            CheckTouchWithBorder(_snake.HeadPosition);
            if (_snake.HeadPosition == _point.Position)
            {
                _snake.Eat();
                _isPointExist = false;
            }
        }

        private void CheckTouchWithBorder(Position headPos) 
        {
            if (headPos.PosX == -1 || headPos.PosX == _mapSize.PosX || headPos.PosY == -1 || headPos.PosY == _mapSize.PosY - 1)
            {
                _snake.TouchintWall();
            }

        }

    }
}
