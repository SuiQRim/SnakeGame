using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class PlayerProfil : AMenuElement
    {
        public PlayerProfil(Player player, IScore scoreObserver) : base(player, scoreObserver, "Профиль")
        {

        }

        public override Menu Do()
        {
            List<GameResult> results = _scoreObserver.LoadGameResultsOfPlayer();
            List<string> listOfgResults = CreateTable(results);
            View.WriteMenuInfoWindow(listOfgResults, ConsoleColor.White);
            Console.ReadKey();

            return new MainMenu(_player, _scoreObserver);
        }

        public static List<string> CreateTable(List<GameResult> gameResults)
        {

            gameResults.Sort((s1, s2) => s2.TimeToCreate.CompareTo(s1.TimeToCreate));

            List<string> results = new();
            results.Add($"{"Очки",-6} {"Время жизни",16} {"Дата рекорда",18}");
            foreach (GameResult r in gameResults)
            {
                results.Add($"{r.Score,-6} {string.Format("{0:00}:{1:00}:{2:00}",
                    r.LifeTime.Hours,
                    r.LifeTime.Minutes,
                    r.LifeTime.Seconds),16} {string.Format("{0:00}:{1:00}:{2:0000}",
                    r.TimeToCreate.Day,
                    r.TimeToCreate.Month,
                    r.TimeToCreate.Year),18}");
            }

            return results;
        }
    }
}
