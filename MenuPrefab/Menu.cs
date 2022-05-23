using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;
using SnakeGame.MenuPrefab.MenuItems;

namespace SnakeGame.MenuPrefab
{
    internal abstract class Menu
    {
        private const int LEFTMARGIN = 10;
        private const int TOPMARGIN = 5;

        public Menu()
        {
            WriteMenuElements += View.WriteAllMenuElement;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;

            _directionController = new(this);
        }

        protected event Action<int, int, List<MenuElement>> WriteMenuElements;

        protected event Action<int, int, List<MenuElement>, int> ChangeSelectedMenuElement;

        protected readonly MenuKeyController _directionController;

        protected int _index = 0;

        protected List<MenuElement> _menuElements;

        protected void WriteMenu() 
        {
            WriteMenuElements?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements);
            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index);
        } 

        public void EnterMenuElement()
        {
            _directionController.StopReadKey();
            _menuElements[_index].Do();
        }

        public virtual void ChangeSelectedMenuItem(Direction direction) 
        {
            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, _menuElements, _index);
        }
    }
}
