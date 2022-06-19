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

        public int Id { get; set; }

        public string ComputerId { get; set; }

        public int Score { get; set; }
        
        public TimeSpan LifeTime { get; set; }

        public DateTime TimeToCreate { get; set; }
    }
}
