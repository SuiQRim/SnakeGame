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

        public int Id { get; set; }
        
        public string ComputerId { get; set; }

        public string NickName { get;  set; }

        public DateTime DateToCreate { get; set; }
    }
}
