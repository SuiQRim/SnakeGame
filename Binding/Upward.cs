namespace SnakeGame.Binding
{
    internal class UpWard : Direction
    {
        public UpWard() : base ("Вверх")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.W,
                ConsoleKey.UpArrow
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
