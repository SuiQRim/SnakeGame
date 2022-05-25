namespace SnakeGame.Game
{
    internal class GameResult
    {
        public GameResult()
        {

        }

        public GameResult( int score, TimeSpan lifeTime, string computerId)
        {
            Score = score;
            LifeTime = lifeTime;
            ComputerId = computerId;
            TimeToCreate = DateTime.Now;
        }

        public int Id { get; private set; }

        public string ComputerId { get; private set; }

        public int Score { get; private set; }
        
        public TimeSpan LifeTime { get; private set; }

        public DateTime TimeToCreate { get; private set; }
    }
}
