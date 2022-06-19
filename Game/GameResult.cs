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
            PlayerNickName = computerId;
            TimeToCreate = DateTime.Now;
        }

        public int Id { get; set; }

        public string PlayerNickName { get; set; }

        public int Score { get; set; }
        
        public TimeSpan LifeTime { get; set; }

        public DateTime TimeToCreate { get; set; }
    }
}
