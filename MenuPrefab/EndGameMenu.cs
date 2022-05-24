using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;

namespace SnakeGame.MenuPrefab
{
    internal class EndGameMenu : Menu
    {
        public EndGameMenu(Player player, GameResult lastGameResult) : base(player)
        {
            _menuElements = new()
            {
                new RestartGame(player),
                new LeaveToMainMenu(player)
            };

            View.WriteMenuInfoWindow(new List<string>() 
            {   
                $"Результаты последней игры:",
                $"Набранные очки:  {lastGameResult.Score}",
                $"   Время жизни:  {string.Format("{0:00}:{1:00}:{2:00}",
                                                  lastGameResult.LifeTime.Hours,
                                                  lastGameResult.LifeTime.Minutes,
                                                  lastGameResult.LifeTime.Seconds)}"
            }) ;
        }

    }
}
