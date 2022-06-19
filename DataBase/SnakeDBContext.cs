using System.Data.Entity;
using SnakeGame.Game;

namespace SnakeGame.GameData
{
    internal class SnakeDBContext : DbContext
    {
        public SnakeDBContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SnakeDB;Integrated Security=True")
        {

        }

        public DbSet<Player> Players { get; set; }

        public DbSet<GameResult> GameResults { get; set; }
    }
}
