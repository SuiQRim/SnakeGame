using SnakeGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SnakeGame.DataBase
{
    internal class LocalDB : Observer
    {
        public LocalDB()
        {
            DataExistence();
        }
        public LocalDB(Player player) : base(player)
        {
            DataExistence();
        }

        private const string PLAYERS = @"Players.json";
        private const string RESULTS = @"Results.json";
        private void DataExistence() 
        {
            if (!File.Exists(PLAYERS))
            {
                CreateJson(PLAYERS);
            }
            if (!File.Exists(RESULTS))
            {
                CreateJson(RESULTS);
            }
        }

        private void CreateJson(string path)
        {
            File.Create(path).Close();
            File.WriteAllText(path, "[]");
        }

        public override List<Player> LoadAllPlayers()
        {
            string text = File.ReadAllText(PLAYERS);

            List<Player> players = new();

            return JsonSerializer.Deserialize<List<Player>>(text).ToList();

        }

        public override List<GameResult> LoadBestResultsFromListOfPlayer()
        {
            List<Player> players = LoadAllPlayers();

            List<GameResult> gameResults;

            List<GameResult> BestGameResults = new();

            foreach (Player p in players)
            {
                gameResults = LoadGameResultsOfPlayer(p).Where(r => r.PlayerNickName == p.NickName).ToList();
                gameResults.Sort((r1, r2) => r2.Score.CompareTo(r1.Score));
                BestGameResults.Add(gameResults.FirstOrDefault());
            }

            return BestGameResults;

        }

        public override List<GameResult> LoadGameResultsOfPlayer()
        {
            return LoadGameResultsOfPlayers().Where(r => r.PlayerNickName == _player.NickName).ToList();
        }
        public List<GameResult> LoadGameResultsOfPlayer(Player player)
        {
            return LoadGameResultsOfPlayers().Where(r => r.PlayerNickName == player.NickName).ToList();
        }

        public override List<GameResult> LoadGameResultsOfPlayers()
        {
            string text = File.ReadAllText(RESULTS);

            return JsonSerializer.Deserialize<List<GameResult>>(text).ToList();
         
        }

        public override void SaveGameResult(GameResult gameResult)
        {
            List<GameResult> results = LoadGameResultsOfPlayers();

            results.Add(gameResult);
            
            var json = JsonSerializer.Serialize(results);
            File.WriteAllText(RESULTS, json);
        }

        public override void AddPlayer(Player player)
        {
            string path = PLAYERS;
            List<Player> players = LoadAllPlayers();
            players.Add(player);

            string json = JsonSerializer.Serialize(players);
            File.WriteAllText(path, json);
        }

        public override bool PlayerExists(Player player)
        {
            return LoadAllPlayers().Exists(p => p.NickName == player.NickName);
        }

        public override bool LoadPlayerByNickName()
        {
            throw new NotImplementedException();
        }
    }
}
