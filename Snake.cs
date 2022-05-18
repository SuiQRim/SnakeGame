using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public Snake()
        {

        }
        
        private async void MoveUpData()
        {
        }

        public Skin Skin { get; set; }

        public int[] _headPos;

        public int[] _bodyPos;

        private event Action<ConsoleKey> Direction_KeyClick; 

        public Direction _direction;
        
        // Сыт? Нужен для отращивания хвоста после получения поинта
        private bool IsFull;
    }
}
