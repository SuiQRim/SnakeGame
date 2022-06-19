using System;
using System.Linq;
using SnakeGame.Game;

namespace SnakeGame.GameData
{
    internal class Observer
    {
        public Observer()
        {
            if (!_snakeDB.Database.Exists())
            {
                throw new Exception();
            }

        }
        private readonly SnakeDBContext _snakeDB = new();
        public bool IsPlayerExist(string computerName) => new SnakeDBContext().Players.Any(p => p.ComputerId == computerName);

        public void AddPlayer(string computerName, string nickName) 
        {
            _snakeDB.Players.Add(new Player(computerName, nickName));
            _snakeDB.SaveChanges();
        }

        public Player GetPlayerByComputerId(string computerId) 
        {
            Player pforil;
            try
            {
                pforil = _snakeDB.Players.Where(p => p.ComputerId == computerId).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
            return pforil;
        }

        ////-
        //public List<GameResult> GetAllResultFromPlayer( Player player) {

        //    return _snakeDB.GameResults.Where(r => r.ComputerId == player.ComputerId).ToList();
        //}

        ////-
        //public List<GameResult> GetBestGameResultsFromProfils(List<Player> profils) 
        //{
        //    List<GameResult> gameResults;

        //    List<GameResult> BestGameResults = new();

        //    foreach (Player p in profils)
        //    {
        //        gameResults = _snakeDB.GameResults.Where(r => r.ComputerId == p.ComputerId).ToList();
        //        gameResults.Sort((r1 , r2 )=> r2.Score.CompareTo(r1.Score));
        //        BestGameResults.Add(gameResults.FirstOrDefault());
        //    }

        //    return BestGameResults;
        //}

        ////-
        //public void SetGameResult(GameResult gameResult) 
        //{
        //    _snakeDB.GameResults.Add(gameResult);
        //    _snakeDB.SaveChanges();
        //}

        //-
        public List<Player> GetAllProfils() 
        {
            return _snakeDB.Players.ToList();
        }


    }
}
