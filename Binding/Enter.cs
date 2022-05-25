namespace SnakeGame.Binding
{
    internal class Enter : Direction
    {
        public Enter() : base("Принять")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.Enter
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
