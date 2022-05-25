using SnakeGame.SnakePrefab;

namespace SnakeGame.Game
{
    internal class Scene
    {
        private const int SLEEP = 150;

        public Scene(int width, int heigh, Player player)
        {
            _snake = new Snake(width, heigh);
            _mapSize = new Position(width, heigh);
            _player = player;

            MapUpData += View.WriteMap;
            SnakeUpData += View.WriteSnake;
            TimeUpData += View.UpDataLifeTime;
            ChangeScore += View.UpDataScore;
        }

        private Player _player;
        private Snake _snake;
        private Point _point;
        private int _score;

        private bool _isPointExist = false;

        private Position _mapSize;

        public GameResult GameResult { get; private set; }

        private event Action<Point, Position> MapUpData;
        private event Action<List<Segment>, Position> SnakeUpData;
        private event Action<TimeSpan, Position> TimeUpData;
        private event Action<int, Position> ChangeScore;

        public void Start() 
        {
            SpawnPoint();
            MapUpData?.Invoke(_point, _mapSize);
            SnakeUpData?.Invoke(_snake.BodyList, _mapSize);

            View.WriteUnderMapWithSleep("Нажмите чтобы начать", _mapSize);
            View.StartConfigurate(_mapSize);
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
                 
                SnakeUpData?.Invoke(_snake.BodyList, _mapSize);
                
                Thread.Sleep(SLEEP);
            }

            DateTime end = DateTime.Now;

            GameOver(start, end);
        }

        private void GameOver(DateTime start, DateTime end) 
        {
            MapUpData?.Invoke(_point, _mapSize);

            GameResult = new GameResult(_score, end - start, _player.ComputerId);

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
                ChangeScore?.Invoke(++_score, _mapSize);
                
                _isPointExist = false;
            }
        }

        private void CheckTouchWithBorder(Position headPos) 
        {
            if (headPos.PosX == -1 || headPos.PosX == _mapSize.PosX || headPos.PosY == -1 || headPos.PosY == _mapSize.PosY)
            {
                _snake.TouchingWall();
            }

        }

        private void TimeStep() 
        {
            int second = 0; 

            while (_snake.IsAlive) 
            {
                
                TimeUpData?.Invoke(new TimeSpan(second * 10000000),_mapSize);
                second++;
                Thread.Sleep(1000);
            }
        }
    }
}
