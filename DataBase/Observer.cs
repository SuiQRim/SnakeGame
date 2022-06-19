using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.DataBase
{
    abstract class Observer : IScore, IAccount
    {
        public Observer()
        {

        }
        public Observer(Player player)
        {
            _player = player;
        }

        public void OnConfigurate(Player player)
        {
            _player = player;
        }

        protected Player _player;

        public abstract void SaveGameResult(GameResult gameResult);

        public abstract List<Player> LoadAllPlayers();

        public abstract List<GameResult> LoadBestResultsFromListOfPlayer();

        public abstract List<GameResult> LoadGameResultsOfPlayer();

        public abstract List<GameResult> LoadGameResultsOfPlayers();

        public abstract void AddPlayer(Player player);

        public abstract bool PlayerExists(Player player);

        public abstract bool LoadPlayerByNickName();

    }
}
