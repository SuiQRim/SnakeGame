using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public Snake()
        {

        }

        // Сыт? Нужен для отращивания хвоста после получения поинта
        private int[] _headPos;
        private char[,] _bodyMap;
        private bool IsFull;
        

        private event Action<ConsoleKey> Direction_KeyClick; 

        public Direction _direction;

        private async void MoveUpData()
        {
        }

        public Skin Skin { get; set; }

        public char[,] BodyMap
        {
            get { return _bodyMap; }
        }


        
       
    }
}
