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
        private const int SLEEP = 250;

        public Scene(int width, int heigh, Snake snake, View view)
        {
            _width = width;
            _height = heigh;
            _snake = snake;
            minPos = new Position(0, 0);
            maxPos = new Position(width, heigh);

            MapUpData += view.WriteMap;
            SnakeUpData += view.WriteSnake;

            _snake.ConfigureStartingParameters(0,0/*width / 2, heigh / 2*/);
            SpawnPoint();
            MapUpData?.Invoke(_point, maxPos);
            StartSprint();
            MapUpData?.Invoke( _point, maxPos);
        }

        private Snake _snake;
        private Point _point;
        private bool _isPointExist;

        private int _width;
        private int _height;

        private Position minPos;
        private Position maxPos;

        private TimeSpan _roundTime;

        private event Action<Point, Position> MapUpData;

        private event Action<List<Segment>> SnakeUpData;

        public void StartSprint() 
        {
            while (_snake.IsAlive)
            {
                _snake.Move();
                CheckCollision();
                MapUpData?.Invoke(_point, maxPos);
                SnakeUpData?.Invoke(_snake.BodyList);
                Thread.Sleep(SLEEP);
            }
        }

        private void SpawnPoint() 
        {
            if (_isPointExist == false)
            {
                Random random = new();
                int posX = random.Next(1, _width - 1);
                int posY = random.Next(1, _height - 1);

                _point = new(new Position(posX, posY));
                _isPointExist = true;
            }
        }

        private void CheckCollision() 
        {
            if (_snake.HeadPosition == _point.Position)
            {
                _snake.Eat();
                SpawnPoint();
                MapUpData?.Invoke(_point, maxPos);
                _isPointExist = false;
            }
        }
        
        const char VERTICALBORDER = '‖';
        const char HORIZONTALBORDER = '=';
        const char POINT = 'Ó';

    }
}
