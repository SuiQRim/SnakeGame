using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaderBoard : AMenuElement
    {
        public LeaderBoard(Player player, IScore scoreObserver) : base(player, scoreObserver, "Таблица лидеров")
        {

        }

        public override Menu Do()
        {
            List<Player> profils = _scoreObserver.LoadAllPlayers();
            List<GameResult> gameResults = _scoreObserver.LoadBestResultsFromListOfPlayer();
            List<string> results = CreateTable(profils ,gameResults);

            View.WriteMenuInfoWindow(results, ConsoleColor.White);
            Console.ReadKey();
            return new MainMenu(_player, _scoreObserver);
        }


        public static List<string> CreateTable(List<Player> profils, List<GameResult> gameResults)
        {
            string nickName = "";

            gameResults.RemoveAll(r => r == null);

            if (gameResults.Count > 1)
            {
                gameResults.Sort((s1,s2) => s2.Score.CompareTo(s1.Score));
            }

            List<string> results = new();
            results.Add($"{"Никнейм",-16} {"Очки",6} {"Время жизни",16} {"Дата рекорда",18}");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (GameResult r in gameResults)
            {
                if (r == null)
                {
                    results.Add($"{nickName, - 14}   Нет результатов");
                    continue;
                }
                nickName = profils.Where(p => p.NickName == r.PlayerNickName).Single().NickName;

                results.Add( $"{nickName,-16} {r.Score,6} {string.Format("{0:00}:{1:00}:{2:00}", 
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
