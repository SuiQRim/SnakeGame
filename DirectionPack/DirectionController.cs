using System;
using System.Collections.Generic;
using System.Linq;
using SnakeGame.Orintation;

namespace SnakeGame
{
    internal class DirectionController : KeyController
    {
        public DirectionController() : base()
        {
            Direction = new RightWard();
        }

        protected override void DetermineDirection(ConsoleKey key) 
        {
            switch (key) 
            {
                case ConsoleKey.UpArrow:
                    Direction = new UpWard();
                    break;
                case ConsoleKey.DownArrow:
                    Direction = new DownWard();
                    break;
                case ConsoleKey.RightArrow:
                    Direction = new RightWard();
                    break;
                case ConsoleKey.LeftArrow:
                    Direction = new LeftWard();
                    break;
            }
        }
    }
}
