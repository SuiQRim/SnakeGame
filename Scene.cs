using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Scene
    {
        public Scene(int width, int heigh, Snake snake, View view)
        {
            _width = width;
            _height = heigh;
            _snake = snake;
            CreateMap();
            MapUpData += view.WriteMap;

            StartSprint();
            MapUpData?.Invoke(_map);

            Thread.Sleep(1000);
            SpawnPoint();
        }

        private Snake _snake;
        private int _width;
        private int _height;
        private TimeSpan _roundTime;

        private char[,] _map;
        public char [,] Map
        {
            get { return _map; }
        }

        private event Action<char [,]> MapUpData;

        public void StartSprint() 
        {
            while (_snake.IsAlive)
            {
                SpawnPoint();
                MapUpData?.Invoke(_map);
                Thread.Sleep(1000);
            }
        }

        private void SpawnPoint() 
        {
            Random random = new();
            int posX = random.Next(1, _width - 1);
            int posY = random.Next(1, _height - 1);

            _map[posX, posY] = POINT;
            MapUpData?.Invoke(_map);
        }

        private void EnemyMove() 
        {
        
        }
        
        private string PrintMap() { return ""; }

        const char VERTICALBORDER = '|';
        const char HORIZONTALBORDER = '—';
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
