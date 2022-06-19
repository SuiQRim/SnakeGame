using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;
using SnakeGame.DataBase.Score;

namespace SnakeGame.MenuPrefab
{
    internal class EndGameMenu : Menu
    {
        public EndGameMenu(Player player, GameResult lastGameResult, IScoreController scoreObserver) 
            : base(player, scoreObserver)
        {
            _menuElements = new()
            {
                new RestartGame(player, _scoreObserver),
                new LeaveToMainMenu(player, _scoreObserver)
            };

            View.WriteMenuInfoWindow(new List<string>() 
            {   
                $"Результаты последней игры:",
                $"Набранные очки:  {lastGameResult.Score}",
                $"   Время жизни:  {string.Format("{0:00}:{1:00}:{2:00}",
                                                  lastGameResult.LifeTime.Hours,
                                                  lastGameResult.LifeTime.Minutes,
                                                  lastGameResult.LifeTime.Seconds)}"
            }, 
            ConsoleColor.Blue) ;
        }

    }
}
