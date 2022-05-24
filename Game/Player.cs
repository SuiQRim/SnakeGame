using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Game
{
    internal class Player
    {
        public Player()
        {

        }
        public Player(string computerName, string nickName)
        {
            ComputerId = computerName;
            NickName = nickName;
            DateToCreate = DateTime.Now;
        }

        public int Id { get; private set; }
        
        public string ComputerId { get; private set; }

        public string NickName { get; private set; }

        public DateTime DateToCreate { get; private set; }
    }
}
