using System.Data.Entity;
using SnakeGame.Game;

namespace SnakeGame.DataBase
{
    internal class SnakeDBContext : DbContext
    {
        public SnakeDBContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sna;Integrated Security=True; Connect Timeout=3;")
        {

        }

        public DbSet<Player> Players { get; set; }

        public DbSet<GameResult> GameResults { get; set; }
    }
}
