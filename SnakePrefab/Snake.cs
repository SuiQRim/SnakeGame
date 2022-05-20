using SnakeGame.SnakePrefab;


namespace SnakeGame
{
    internal class Snake
    {

        public Snake(Skin skin, int headPosX, int headPosY)
        {
            
            _isAlive = true;
            _head = new Head(new Position(headPosX / 2, headPosY / 2), this);
        }

        
        public void Eat()
        {
            _head.Grow();
        }

        public void Move()
        {
            _head.Move();
        }
        public void TouchintWall()
        {
            Die();
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

        private bool _isAlive;

        public void Die() { _isAlive = false; }
        public bool IsAlive
        {
            get => _isAlive;
        }



    }
}
