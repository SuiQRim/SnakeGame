using SnakeGame.SnakePrefab;

namespace SnakeGame.Binding
{
    internal class DownWard : Direction
    {
        public DownWard() : base("Вниз")
        {
            keyValues = new List<ConsoleKey>()
            {
                ConsoleKey.S,
                ConsoleKey.DownArrow
            };
        }
        public override string Print()
        {
            throw new NotImplementedException();
        }
    }
}
