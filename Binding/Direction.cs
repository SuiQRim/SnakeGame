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
            switch (direction) 
            {
                case UpWard: return new DownWard();
                case DownWard: return new UpWard();
                case RightWard: return new LeftWard();
                case LeftWard: return new RightWard();
                default: throw new ArgumentNullException();
            }
             
        }
        public abstract string Print();
    }
}
