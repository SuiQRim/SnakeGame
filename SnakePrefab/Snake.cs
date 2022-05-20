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

        public void Eat() { }

        public void Move() 
        {
            _bodyList.Where(s => s.GetType() == typeof(Head)).SingleOrDefault().Move();
        }
        public void ConfigureStartingParameters(int headPosX, int headPosY)
        {
            _bodyList = new List<Segment> { new Head(new Position(headPosX, headPosY))};
        }

        private List<Segment> _bodyList;
        public List<Segment> BodyList 
        { 
            get => _bodyList;
        }

        // Сыт? Нужен для отращивания хвоста после получения поинта
        private bool _isFull;
        private bool _isAlive;

        public void Die() { _isAlive = false; }
        public bool IsAlive
        {
            get => _isAlive;
        }



    }
}
