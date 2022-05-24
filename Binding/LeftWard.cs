namespace SnakeGame.Binding
{
    internal class LeftWard : Direction
    {
        public LeftWard() : base("Влево")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.A,
                ConsoleKey.LeftArrow
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
