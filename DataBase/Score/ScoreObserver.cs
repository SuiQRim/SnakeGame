﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.DataBase.ResultDB;
using SnakeGame.Game;

namespace SnakeGame.GameData.Score
{
    abstract class ScoreObserver : IGameResultController
    {
        public ScoreObserver(Player player)
        {
            _player = player;
        }

        protected readonly Player _player;

        public abstract void SaveGameResult(GameResult gameResult);

        public abstract List<Player> LoadAllPlayers();

        public abstract List<GameResult> LoadBestResultsFromListOfPlayer();

        public abstract List<GameResult> LoadGameResults();

        
    }
}
