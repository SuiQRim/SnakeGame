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
            CreateTable(profils ,gameResults);
            
            return new MainMenu(_player);
        }


        public static string CreateTable(List<Player> profils, List<GameResult> gameResults)
        {
            string text = "";
            Console.ForegroundColor = ConsoleColor.White;
            foreach (GameResult r in gameResults)
            {
                text += $"|| {profils.Where(p => p.ComputerId == r.ComputerId).Single().NickName,16} {r.Score,4} {r.LifeTime,12} {r.TimeToCreate,12}\n";
            }

            Console.WriteLine(text);
            Console.ReadKey();

            return text;
        }
    }
}
