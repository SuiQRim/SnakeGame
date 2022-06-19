using SnakeGame.Binding;
using SnakeGame.Game;
using SnakeGame.MenuPrefab.MenuItems;

namespace SnakeGame.MenuPrefab
{
    internal class MainMenu : Menu
    {
        public MainMenu(Player player) : base (player)
        {
            _menuElements = new()
            {
                new Start(_scoreObserver),
                new LeaderBoard(_scoreObserver),
                new PlayerProfil(_scoreObserver),
                new Exit(_scoreObserver)
            };

            _player = player;

            View.WriteMenuInfoWindow(new List<string>() {$"Приветствую {player.NickName}!" }, ConsoleColor.Blue);
           
        }

        private Player _player;

    }
}
