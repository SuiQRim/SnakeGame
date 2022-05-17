using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Scene
    {

        private int _width;
        private int _height;
        private TimeSpan _roundTime;

        private int [] _map;
        public int [] Map
        {
            get { return _map; }
        }

        private void SpawnPoint() 
        {
        
        }
        private void EnemyMove(Snake snake) 
        {
        
        }
        
        private string PrintMap() { return ""; }
    }
}
