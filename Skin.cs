using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Skin
    {
        public Skin(char mainDecor, char sideDecor)
        {
            _mainDecoration = mainDecor;
            _sideDecoration = sideDecor;
        }
        private char _mainDecoration;
        private char _sideDecoration;

        public char MainDecoration
        {
            get => _mainDecoration; 
            set => _mainDecoration = value; 

        }
        public char SideDecoration
        {
            get => _sideDecoration;
            set => _sideDecoration = value;
        }

    }
}
