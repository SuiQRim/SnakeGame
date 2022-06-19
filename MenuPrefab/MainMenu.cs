using SnakeGame.Binding;
using SnakeGame.Game;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab
{
    internal class MainMenu : Menu
    {
        public MainMenu(Player player, IScore scoreObserver) : base (player, scoreObserver)
        {
            _menuElements = new()
            {
                new Start(player, _scoreObserver),
                new LeaderBoard(player, _scoreObserver),
                new PlayerProfil(player, _scoreObserver),
                new Exit(player, _scoreObserver)
            };

            _player = player;

            View.WriteMenuInfoWindow(new List<string>() {$"Приветствую {player.NickName}!" }, ConsoleColor.Blue);
           
        }

        private Player _player;

    }
}
