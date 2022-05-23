using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Orintation;

namespace SnakeGame.MenuPrefab
{
    internal class MenuKeyController : KeyController
    {
        public MenuKeyController(Menu menu) : base()
        {
            ChangeDirection += menu.ChangeSelectedMenuItem;
            PressEnter += menu.EnterMenuElement;
        }

        
        private event Action<Direction> ChangeDirection;

        private event Action PressEnter;

        protected override void DetermineDirection(ConsoleKey key)
        {
            switch (key) 
            {
                case ConsoleKey.UpArrow:
                    Direction = new UpWard();
                    ChangeDirection?.Invoke(Direction);
                    break;

                case ConsoleKey.DownArrow:
                    Direction = new DownWard();
                    ChangeDirection?.Invoke(Direction);
                    break;
                case ConsoleKey.Enter:
                    Direction = new Enter();
                    PressEnter?.Invoke();
                    break;
            }


        }
    }
}
