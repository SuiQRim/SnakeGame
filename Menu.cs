using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;
using SnakeGame.Skins;

namespace SnakeGame
{
    internal class Menu
    {
        private const int LEFTMARGIN = 5;
        private const int TOPMARGIN = 5;
        private const int MENUITEMMAXLENGTH = 16;
        public Menu()
        {
            WriteMenuElements += View.WriteAllMenuElement;
            ChangeSelectedMenuElement += View.WriteSelectedMenuElement;

            _directionController = new(this);
            WriteMenuElements?.Invoke(LEFTMARGIN, TOPMARGIN, MENUITEMMAXLENGTH, _menuElements);
            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, MENUITEMMAXLENGTH, _menuElements, _menuElements[_index], _index);

        }

        private event Action<int, int, int, List<string>> WriteMenuElements;

        private event Action<int, int, int, List<string>, string, int> ChangeSelectedMenuElement;

        private MenuController _directionController;

        private Position _cursorPosition;

        private int _index = 0;

        private List<string> _menuElements = new() 
        {
            "Старт",
            "Лидерборд",
            "Профиль",
            "Выйти"
        };

        public void EnterMenuElement() 
        {
            switch (_index)
            {
                case 0:
                    _directionController.StopReadKey();
                    Scene scene = new(15, 15, new Snake(new DefaultSkin(),15,15));
                    scene.StartSprint();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

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


            ChangeSelectedMenuElement?.Invoke(LEFTMARGIN, TOPMARGIN, MENUITEMMAXLENGTH, _menuElements, _menuElements[_index], _index);
        }
    }
}
