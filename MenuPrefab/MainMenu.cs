using SnakeGame.Binding;
using SnakeGame.Game;
using SnakeGame.MenuPrefab.MenuItems;

namespace SnakeGame.MenuPrefab
{
    internal class MainMenu : Menu
    {
        public MainMenu() : base()
        {
            _menuElements = new()
            {
                new Start(),
                new LeaderBoard(),
                new PlayerProfil(),
                new Exit()
            };
           
        }

    }
}
