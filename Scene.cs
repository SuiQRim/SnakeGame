using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;
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
            CreateMap();
            MapUpData += view.WriteMap;
            SnakeUpData += view.WriteSnake;

            _snake.ConfigureStartingParameters(width / 2, heigh / 2);
            SpawnPoint();
            StartSprint();
            MapUpData?.Invoke(_map, _point);
        }

        private Snake _snake;
        private Point _point;
        private bool _isPointExist;

        private int _width;
        private int _height;
        private TimeSpan _roundTime;

        private char[,] _map;
        public char [,] Map
        {
            get { return _map; }
        }

        private event Action<char[,], Point> MapUpData;
        private event Action<List<Segment>> SnakeUpData;

        public void StartSprint() 
        {
            while (_snake.IsAlive)
            {
                _snake.Move();
                CheckCollision();
                MapUpData?.Invoke(_map, _point);
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

                _point = new(new Position(posX, posY ));
                _isPointExist = true;
            }
        }

        private void CheckCollision() 
        {
            switch (Map[_snake.HeadPosition.PosX + 2, _snake.HeadPosition.PosY + 2])
            {
                case VERTICALBORDER:
                    _snake.Die();
                    break;
                case HORIZONTALBORDER:
                    _snake.Die();
                    break;
            }
            if (_snake.HeadPosition + 1 == _point.Position)
            {
                _snake.Eat();
                SpawnPoint();
                _isPointExist = false;
            }
        }
        
        const char VERTICALBORDER = '‖';
        const char HORIZONTALBORDER = '=';
        const char POINT = 'Ó';

        private void CreateMap() 
        {
            int wight = _width + 2;
            int height = _height + 2;

            _map = new char [height, wight];

            for (int i = 0; i != wight; i++)
            {
                _map[0, i] = HORIZONTALBORDER;
                _map[height - 1, i] = HORIZONTALBORDER;
            }

            for (int i = 0; i < height; i++) 
            {
                _map[i, 0] = VERTICALBORDER;
                _map[i, wight - 1] = VERTICALBORDER;
            }
        }

    }
}
