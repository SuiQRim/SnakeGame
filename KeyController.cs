using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal abstract class KeyController
    {
        public KeyController()
        {
            new Thread(() => ReadAllKey()).Start();
        }
        
        private Direction _direction;
        public Direction Direction
        {
            get => _direction;
            set => _direction = value;
        }

        public void StopReadKey() 
        {
            _readKey = false;
        }

        private bool _readKey = true;
        protected void ReadAllKey()
        {
            while (_readKey)
            {
                ConsoleKey key = Console.ReadKey().Key;
                DetermineDirection(key);
            }

        }

        protected abstract void DetermineDirection(ConsoleKey key);

    }
}
