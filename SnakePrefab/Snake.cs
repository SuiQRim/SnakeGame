using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;
using SnakeGame.SnakePrefab;


namespace SnakeGame
{
    internal class Snake
    {

        public Snake(Skin skin)
        {
            _isAlive = true;
        }

        public void UpData()
        {

            if (_isFull)
            {
                Eat();
            }
            Move();
        }
        public void Eat()
        {
            _head.Grow();
        }

        public void Move()
        {
            _head.Move();
        }
        public void ConfigureStartingParameters(int headPosX, int headPosY)
        {
            _head = new Head(new Position(headPosX, headPosY));

        }

        private Head _head;

        public Position HeadPosition 
        {
            get => _head.Position;
        }

        public List<Segment> BodyList 
        {
            get => _head.AddToListOfSegment(new List<Segment>());
        }

        // Сыт? Нужен для отращивания хвоста после получения поинта
        private bool _isFull = true;
        private bool _isAlive;

        public void Die() { _isAlive = false; }
        public bool IsAlive
        {
            get => _isAlive;
        }



    }
}
