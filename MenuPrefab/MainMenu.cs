using SnakeGame.Binding;
using SnakeGame.Game;
using SnakeGame.MenuPrefab.MenuItems;

namespace SnakeGame.MenuPrefab
{
    internal class MainMenu : Menu
    {
        public MainMenu(Player player) : base(player)
        {
            _menuElements = new()
            {
                new Start(player),
                new LeaderBoard(player),
                new PlayerProfil(player),
                new Exit(player)
            };

            _player = player;
           
        }

        private Player _player;

    }
}
