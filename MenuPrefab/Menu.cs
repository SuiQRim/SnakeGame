using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Binding;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;
namespace SnakeGame.MenuPrefab
{
    internal abstract class Menu
    {

        private const int LEFTMARGIN = 10;
        private const int TOPMARGIN = 5;

        protected static object isMenuUsing = new ();

        public Menu(Player player)
        {
            _player = player;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;
        }

        protected Player _player;
        public void Start() 
        {
            _index = 0;
            _directionController = new(this);
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;
            WriteMenu();
        }

        protected event Action<int, int, List<AMenuElement>, int, bool> ChangeSelectedMenuElement;

        protected MenuKeyController _directionController;

        protected int _index;

        protected List<AMenuElement> _menuElements;

        protected void WriteMenu() 
        {
            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index, true);
        } 

        public void EnterMenuElement()
        {
            Console.Clear();
            _directionController.StopReadKey();
            _menuElements[_index].Do().Start();
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

            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index, false);
        }
    }
}
