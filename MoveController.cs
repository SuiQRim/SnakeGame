using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;

namespace SnakeGame
{
    internal class MoveController
    {

        private event Action<ConsoleKey> Direction_KeyClick;

        private Direction _direction;
        public Direction Direction 
        { 
            get => _direction;
        }

        public void ReadAllKey()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine(key);
                DetermineDirection(key);
            }

        }

        private void DetermineDirection(ConsoleKey key) 
        {
            switch (key) 
            {
                case ConsoleKey.UpArrow:
                    _direction = new UpWard();
                    break;
                case ConsoleKey.DownArrow:
                    _direction = new DownWard();
                    break;
                case ConsoleKey.RightArrow:
                    _direction = new RightWard();
                    break;
                case ConsoleKey.LeftArrow:
                    _direction = new LeftWard();
                    break;
            }

        }
    }
}
