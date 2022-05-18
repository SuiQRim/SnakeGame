using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Scene
    {
        public Scene(int width, int heigh, Snake snake)
        {
            _width = width;
            _height = heigh;
            _snake = snake;
            CreateMap();
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

        private event Action<string> MapUpData;

        public void Sprint() 
        {
            
        }

        private void SpawnPoint() 
        {
        
        }
        private void EnemyMove() 
        {
        
        }
        
        private string PrintMap() { return ""; }

        const char border = '#';
        private void CreateMap() 
        {
            int wight = _width + 2;
            int height = _height + 2;

            _map = new char [height, wight];

            for (int i = 0; i != wight; i++)
            {
                _map[0, i] = border;
                _map[height - 1, i] = border;
            }

            for (int i = 0; i < height; i++) 
            {
                _map[i, 0] = border;
                _map[i, wight - 1] = border;
            }
        }

    }
}
