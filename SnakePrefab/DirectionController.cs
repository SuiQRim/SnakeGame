using SnakeGame.Binding;

namespace SnakeGame.SnakePrefab
{
    internal class DirectionController : KeyController
    {
        public DirectionController() : base()
        {
            Direction = new RightWard();
        }

        protected override void DetermineDirection(ConsoleKey key) 
        {

            if (new UpWard().KeyValues.Any(w => w == key))
            {
                Direction = new UpWard();
            }
            else if (new DownWard().KeyValues.Any(w => w == key)) 
            {
                Direction= new DownWard();
            }
            else if (new LeftWard().KeyValues.Any(w => w == key))
            {
                Direction = new LeftWard();
            }
            else if     (new RightWard().KeyValues.Any(w => w == key))
            {
                Direction = new RightWard();            
            }

        }
    }
}
