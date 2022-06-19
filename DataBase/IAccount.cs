using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Game;

namespace SnakeGame.DataBase
{
    internal interface IAccount
    {
        public void AddPlayer(Player player);

        public bool PlayerExists(Player player);

        public bool LoadPlayerByNickName();
    }
}
