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

        public Direction _direction;

        public void ReadAllKeyAcync()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine(key);
                DetermineTheDirection(key);
            }

        }
        private void DetermineTheDirection(ConsoleKey key) 
        {


        }
    }
}
