using SnakeGame.Binding;

namespace SnakeGame.MenuPrefab
{
    internal class MenuKeyController : KeyController
    {
        public MenuKeyController(Menu menu) : base()
        {
            ChangeDirection += menu.ChangeSelectedMenuItem;
        }

        private event Action<Direction> ChangeDirection;

        protected override void DetermineDirection(ConsoleKey key)
        {
            if (new UpWard().KeyValues.Any(w => w == key))
            {
                Direction = new UpWard();
            }
            else if (new DownWard().KeyValues.Any(w => w == key))
            {
                Direction = new DownWard();
            }
            else if (new Enter().KeyValues.Any(w => w == key))
            {
                Direction = new Enter();
            }
            ChangeDirection?.Invoke(Direction);
        }
    }
}
