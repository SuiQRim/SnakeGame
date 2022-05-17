using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {
        public Skin Skin { get; set; }

        public int[] _headPos;

        public int[] _bodyPos;

        public string _direction;
        
        // Сыт? Нужен для отращивания хвоста после получения поинта
        private bool IsFull;
    }
}
