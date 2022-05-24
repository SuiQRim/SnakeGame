namespace SnakeGame.Binding
{
    internal class RightWard : Direction
    {
        public RightWard() : base("Вправо")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.RightArrow,
                ConsoleKey.D
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
