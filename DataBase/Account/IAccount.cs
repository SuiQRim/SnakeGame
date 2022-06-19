using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.DataBase.Account
{
    internal interface IAccountController
    {
        public void AddPlayer();

        public bool IsPlayerExists();

        public bool LoadPlayerByNickName();
    }
}
