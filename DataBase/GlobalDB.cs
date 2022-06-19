using SnakeGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.DataBase
{
    internal class GlobalDB : Observer
    {
        public GlobalDB() { }
        public GlobalDB(Player player) : base(player) { }

        private readonly SnakeDBContext _snakeDB = new();

        public override List<Player> LoadAllPlayers()
        {
            return _snakeDB.Players.ToList();
        }

        public override List<GameResult> LoadGameResultsOfPlayer()
        {
            return _snakeDB.GameResults.Where(r => r.PlayerNickName == _player.NickName).ToList();
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
                gameResults = _snakeDB.GameResults.Where(r => r.PlayerNickName == p.NickName).ToList();
                gameResults.Sort((r1, r2) => r2.Score.CompareTo(r1.Score));
                BestGameResults.Add(gameResults.FirstOrDefault());
            }

            return BestGameResults;
        }

        public override List<GameResult> LoadGameResultsOfPlayers()
        {
            return _snakeDB.GameResults.ToList();
        }

        public override void AddPlayer(Player player)
        {
            _snakeDB.Players.Add(player);
        }

        public override bool PlayerExists(Player player)
        {
            return _snakeDB.Players.ToList().Exists(p => p.NickName == player.NickName);
        }

        public override bool LoadPlayerByNickName()
        {
            throw new NotImplementedException();
        }
    }
}
