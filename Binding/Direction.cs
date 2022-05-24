using SnakeGame.Binding;

namespace SnakeGame.Binding
{
    internal abstract class Direction
    {
        public Direction(string orintation) 
        { 
            OrintationName = orintation;
        }

        protected List<ConsoleKey> keyValues;
        public List<ConsoleKey> KeyValues 
        { 
            get => keyValues;
            set => keyValues = value;
        }

        public string OrintationName { get; set; }

        public static Direction GetReverseOrintation(Direction direction) 
        {
            return direction switch
            {
                UpWard => new DownWard(),
                DownWard => new UpWard(),
                RightWard => new LeftWard(),
                LeftWard => new RightWard(),
                _ => throw new ArgumentNullException(),
            };
        }
        public abstract string Print();
    }
}
