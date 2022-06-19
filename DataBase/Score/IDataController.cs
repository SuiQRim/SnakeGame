using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.DataBase.ResultDB
{
    internal interface IGameResultController
    {
        public void SaveGameResult(GameResult gameResult);

        public List<Player> LoadAllPlayers();

        public List<GameResult> LoadBestResultsFromListOfPlayer();

        public List<GameResult> LoadGameResults();
    }
}
