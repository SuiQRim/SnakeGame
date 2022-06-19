﻿using SnakeGame.Game;
using SnakeGame.DataBase;
using SnakeGame.DataBase.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class RestartGame : AMenuElement
    {
        public RestartGame(Player player, IScoreController scoreObserver) : base(player, scoreObserver, "Играть снова")
        {
           
        }
        public override Menu Do()
        {
            Scene scene = new(16, 16, _player);
            scene.Start();

            _scoreObserver.SaveGameResult(scene.GameResult);

            return new EndGameMenu(_player, scene.GameResult, _scoreObserver);
        }
    }
}
