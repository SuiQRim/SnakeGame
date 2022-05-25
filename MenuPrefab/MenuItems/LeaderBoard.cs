using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;
using SnakeGame.DataBase;


namespace SnakeGame.MenuPrefab.MenuItems
{
    internal class LeaderBoard : AMenuElement
    {
        public LeaderBoard(Player player) : base (player,"Таблица лидеров")
        {

        }

        public override Menu Do()
        {
            Observer observer = new();
            List<Player> profils = observer.GetAllProfils();
            List<GameResult> gameResults = observer.GetBestGameResultsFromProfils(profils);
            List<string> results = CreateTable(profils ,gameResults);

            View.WriteMenuInfoWindow(results, ConsoleColor.White);
            Console.ReadKey();
            return new MainMenu(_player);
        }


        public static List<string> CreateTable(List<Player> profils, List<GameResult> gameResults)
        {
            string nickName = "";

            gameResults.Sort((s1,s2) => s2.Score.CompareTo(s1.Score));

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
                nickName = profils.Where(p => p.ComputerId == r.ComputerId).Single().NickName;

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
