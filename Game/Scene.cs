using SnakeGame.SnakePrefab;

namespace SnakeGame.Game
{
    internal class Scene
    {
        private const int SLEEP = 150;

        public Scene(int width, int heigh, Snake snake)
        {
            _snake = snake;
            _mapSize = new Position(width, heigh);

            MapUpData += View.WriteMap;
            SnakeUpData += View.WriteSnake;
            TimeUpData += View.UpDataLifeTime;
            ChangeScore += View.UpDataScore;
        }

        private Snake _snake;
        private Point _point;
        private int _score;

        private bool _isPointExist = false;

        private Position _mapSize;

        private TimeSpan _roundTime;

        private event Action<Point, Position> MapUpData;
        private event Action<List<Segment>> SnakeUpData;
        private event Action<TimeSpan> TimeUpData;
        private event Action<int> ChangeScore;

        public void Start() 
        {
            SpawnPoint();
            MapUpData?.Invoke(_point, _mapSize);
            SnakeUpData?.Invoke(_snake.BodyList);

            View.WriteUnderMapWithSleep("Нажмите чтобы начать", _mapSize);
            View.StartConfigurate();
            Sprint();
        }

        private void Sprint() 
        {
            new Thread(() => TimeStep()).Start();
            DateTime start = DateTime.Now;
            MapUpData?.Invoke(_point, _mapSize);

            while (_snake.IsAlive)
            {
                _snake.Move();
                CheckCollision();
                if (!_isPointExist)
                {
                    SpawnPoint();
                }
                 
                SnakeUpData?.Invoke(_snake.BodyList);
                
                Thread.Sleep(SLEEP);
            }

            DateTime end = DateTime.Now;

            GameOver(start, end);
        }

        private void GameOver(DateTime start, DateTime end) 
        {
            MapUpData?.Invoke(_point, _mapSize);

            _roundTime = end - start;

            View.WriteUnderMapWithSleep("Игра окончена...", _mapSize);
        }

        private void SpawnPoint() 
        {
            if (_isPointExist == false)
            {
                Position pos = Point.SearchClearPosition(_snake.BodyList, _mapSize);

                _point = new(new Position(pos));
                MapUpData?.Invoke(_point, _mapSize);
                _isPointExist = true;
            }
        }

        private void CheckCollision() 
        {
            CheckTouchWithBorder(_snake.HeadPosition);
            if (_snake.HeadPosition == _point.Position)
            {
                _snake.Eat();
                ChangeScore?.Invoke(++_score);
                
                _isPointExist = false;
            }
        }

        private void CheckTouchWithBorder(Position headPos) 
        {
            if (headPos.PosX == -1 || headPos.PosX == _mapSize.PosX || headPos.PosY == -1 || headPos.PosY == _mapSize.PosY - 1)
            {
                _snake.TouchintWall();
            }

        }

        private void TimeStep() 
        {
            int second = 0; 

            while (_snake.IsAlive) 
            {
                
                TimeUpData?.Invoke(new TimeSpan(second * 10000000));
                second++;
                Thread.Sleep(1000);
            }
        }
    }
}
