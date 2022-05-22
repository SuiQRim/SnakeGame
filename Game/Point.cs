﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.SnakePrefab;
namespace SnakeGame.Game
{
    internal class Point
    {
        public Point(Position position)
        {
            _position = position;
        }

        private Position _position;
        public Position Position 
        {
            get => _position;
        }

        public static Position SearchClearPosition(List<Segment> segmentPositions, Position mapMax) 
        {
            Random rnd = new ();
            Position pos;

            do
            {
                pos = new Position(rnd.Next(1, mapMax.PosX), rnd.Next(1, mapMax.PosY) - 1);
            } 
            while (segmentPositions.Any(s => s.Position == pos));

            return pos;
        }

        
        
    }
}