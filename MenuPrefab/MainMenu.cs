using SnakeGame.Orintation;
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
                new MProfil(),
                new Exit()
            };
            
            WriteMenuElements += View.WriteAllMenuElement;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;

            WriteMenu();
        }


        public override void ChangeSelectedMenuItem(Direction direction) 
        {
            switch (direction)
            {
                case UpWard:

                    if (_index - 1 < 0) 
                    { 
                        _index = _menuElements.Count - 1;
                    }

                    else _index--; 

                    break;

                case DownWard:

                    if (_index + 1 > _menuElements.Count - 1)
                    {
                        _index = 0;
                    }
                    else  _index++;

                    break;
            }


            base.ChangeSelectedMenuItem(direction);
        }
    }
}
