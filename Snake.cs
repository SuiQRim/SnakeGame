using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;

namespace SnakeGame
{
    internal class Snake
    {
        public Snake(Skin skin)
        {
            Skin = skin;
            _isAlive = true;
            _moveController = new();
            new Thread(() => _moveController.ReadAllKey()).Start();
        }

        public void Eat() { }
        public void Move()
        {
            BodyMap[_headPosition.PosY - 1, _headPosition.PosX - 1] = Skin.SideDecoration;
            switch (MoveController.Direction)
            {
                case UpWard:
                    _headPosition.PosY--;
                    break;
                case DownWard:
                    _headPosition.PosY++;
                    break;
                case RightWard:
                    _headPosition.PosX++;
                    break;
                case LeftWard:
                    _headPosition.PosX--;
                    break;
            }
        }

        public void ConfigureStartingParameters(
            int mapSizeX, int mapSizeY,int headPosX, int headPosY)
        {
            _headPosition = new(headPosX, headPosY);
            _bodyMap = new char[mapSizeX, mapSizeY];
        }

        private Position _headPosition;
        public Position HeadPosition 
        { 
            get => _headPosition; 
        }

        private char[,] _bodyMap; 

        // Сыт? Нужен для отращивания хвоста после получения поинта
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

        public void Die() { _isAlive = false; }
        public bool IsAlive
        {
            get => _isAlive;
        }



    }
}
