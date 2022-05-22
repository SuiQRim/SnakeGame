using SnakeGame.Orintation;
using SnakeGame.Game;
using SnakeGame.Menu.MenuItems;

namespace SnakeGame.Menu
{
    internal class MainMenu
    {
        private const int LEFTMARGIN = 5;
        private const int TOPMARGIN = 5;
        public MainMenu()
        {
            WriteMenuElements += View.WriteAllMenuElement;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;
             
            _directionController = new(this);
            WriteMenuElements?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements);
            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index);

        }

        private event Action<int, int, List<MenuElement>> WriteMenuElements;

        private event Action<int, int, List<MenuElement>, int> ChangeSelectedMenuElement;

        private MenuController _directionController;

        private int _index = 0;


        private List<MenuElement> _menuElements = new()
        {
            new Start(),
            new Exit()
        };


        public void EnterMenuElement() 
        {
            _directionController.StopReadKey();
            _menuElements[_index].Do();
        }

        public void ChangeSelectedMenuItem(Direction direction) 
        {
            switch (direction) 
            {
                case UpWard:

                    if (_index - 1 < 0)
                    {
                        _index = _menuElements.Count - 1;
                    }
                    else
                    {
                        _index--;
                    }
                    
                    break;

                case DownWard:

                    if (_index + 1 > _menuElements.Count - 1)
                    {
                        _index = 0;
                    }
                    else
                    {
                        _index++;
                    }
                    break;
            }


            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index);
        }
    }
}
