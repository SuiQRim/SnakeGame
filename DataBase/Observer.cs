using System;
using System.Linq;
using SnakeGame.Game;

namespace SnakeGame.DataBase
{
    internal class Observer
    {
        private readonly SnakeDBContext _snakeDB = new();
        public bool IsPlayerExist(string computerName) => new SnakeDBContext().Players.Any(p => p.ComputerId == computerName);

        public void AddPlayer(string computerName, string nickName) 
        {
            _snakeDB.Players.Add(new Player(computerName, nickName));
            _snakeDB.SaveChanges();
        }

        public Player GetPlayerByComputerId(string computerId) 
        {
            Player pforil = _snakeDB.Players.Where(p => p.ComputerId == computerId).SingleOrDefault();

            return pforil;
        }

        public List<GameResult> GetBestGameResultsFromProfils(List<Player> profils) 
        {
            List<GameResult> gameResults;

            List<GameResult> BestGameResults = new();

            foreach (Player p in profils)
            {
                gameResults = _snakeDB.GameResults.Where(r => r.ComputerId == p.ComputerId).ToList();
                gameResults.Sort((r1 , r2 )=> r2.Score.CompareTo(r1.Score));
                BestGameResults.Add(gameResults.FirstOrDefault());
            }

            return BestGameResults;
        }

        public void SetGameResult(GameResult gameResult) 
        {
            _snakeDB.GameResults.Add(gameResult);
            _snakeDB.SaveChanges();
        }

        public List<Player> GetAllProfils() 
        {
            return _snakeDB.Players.ToList();
        }


    }
}
