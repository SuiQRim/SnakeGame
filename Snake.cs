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
            _isAlive = true;
            _moveController = new();
            new Thread(() => _moveController.ReadAllKey()).Start();
        }

        // Сыт? Нужен для отращивания хвоста после получения поинта
        private int[] _headPos;
        private char[,] _bodyMap;
        private bool _isFull;
        private bool _isAlive;

        private MoveController _moveController;
        public MoveController MoveController 
        {
            get { return _moveController; } 
        }

        public Skin Skin { get; set; }

        public char[,] BodyMap
        {
            get { return _bodyMap; }
        }

        public void Die() { }
        public bool IsAlive
        {
            get => _isAlive;
        }



    }
}
