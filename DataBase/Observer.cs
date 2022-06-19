using System;
using System.Linq;
using SnakeGame.Game;

namespace SnakeGame.DataBase
{
    internal class Observer
    {
        public Observer()
        {
            if (!_snakeDB.Database.Exists())
            {
                throw new Exception();
            }

        }
        private readonly SnakeDBContext _snakeDB = new();
        public bool IsPlayerExist(string computerName) => new SnakeDBContext().Players.Any(p => p.ComputerId == computerName);

        public void AddPlayer(string computerName, string nickName) 
        {
            _snakeDB.Players.Add(new Player(computerName, nickName));
            _snakeDB.SaveChanges();
        }

        public Player GetPlayerByComputerNickName(string computerId) 
        {
            Player pforil;
            try
            {
                pforil = _snakeDB.Players.Where(p => p.ComputerId == computerId).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
            return pforil;
        }
    }
}
