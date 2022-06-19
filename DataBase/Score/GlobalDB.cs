using SnakeGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.DataBase.Score
{
    internal class GlobalDB : ScoreObserver
    {
        public GlobalDB(Player player) : base(player) { }

        private readonly SnakeDBContext _snakeDB = new();

        public override List<Player> LoadAllPlayers()
        {
            return _snakeDB.Players.ToList();
        }

        public override List<GameResult> LoadGameResults()
        {
            return _snakeDB.GameResults.Where(r => r.ComputerId == _player.ComputerId).ToList();
        }

        public override void SaveGameResult(GameResult gameResult) 
        {
            _snakeDB.GameResults.Add(gameResult);
            _snakeDB.SaveChanges();
        }

        public override List<GameResult> LoadBestResultsFromListOfPlayer()
        {
            List<Player> players = LoadAllPlayers();

            List<GameResult> gameResults;

            List<GameResult> BestGameResults = new();

            foreach (Player p in players)
            {
                gameResults = _snakeDB.GameResults.Where(r => r.ComputerId == p.ComputerId).ToList();
                gameResults.Sort((r1, r2) => r2.Score.CompareTo(r1.Score));
                BestGameResults.Add(gameResults.FirstOrDefault());
            }

            return BestGameResults;
        }
    }
}
