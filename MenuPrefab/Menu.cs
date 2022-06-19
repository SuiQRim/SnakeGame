using SnakeGame.Binding;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;
using SnakeGame.DataBase;

namespace SnakeGame.MenuPrefab
{
    internal abstract class Menu
    {

        protected static object isMenuUsing = new ();

        public Menu(Player player, IScore scoreObserver)
        {
            _player = player;
            _scoreObserver = scoreObserver;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;
        }

        protected Player _player;

        protected IScore _scoreObserver;

        public void Start() 
        {
            _index = 0;
            _directionController = new(ChangeSelectedMenuItem);
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;
            WriteMenu();
        }

        private event Action<List<AMenuElement>, int> ChangeSelectedMenuElement;

        private MenuKeyController _directionController;

        private int _index;

        protected List<AMenuElement> _menuElements;

        private void WriteMenu() 
        {
            ChangeSelectedMenuElement?.Invoke(_menuElements, _index);
        } 

        private void EnterMenuElement()
        {
            _directionController.StopReadKey();
            _menuElements[_index].Do().Start();
        }

        private void ChangeSelectedMenuItem(Direction direction) 
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
                    else _index++;

                    break;

                case Enter:
                    EnterMenuElement();
                    return;
            }

            ChangeSelectedMenuElement?.Invoke( _menuElements, _index);
        }
    }
}
