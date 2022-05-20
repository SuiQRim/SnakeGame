﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.SnakePrefab;

namespace SnakeGame
{
    internal class View
    {

        public void WriteMap(char [,] map, Point point) 
        {

            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (map[i, j] == default(char))
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write($"{map[i, j]} ");
                    }

                }
                Console.WriteLine();
            }
            Console.SetCursorPosition((point.Position.PosX + 1 ) * 2, point.Position.PosY + 1);
            Console.Write('=');
        }

        public void WriteSnake(List<Segment> bodyList) 
        {
            foreach (Segment segment in bodyList)
            {
                Console.SetCursorPosition((2 + segment.Position.PosX) * 2, 2 + segment.Position.PosY);
                Console.Write(segment);
            }

        }

    }
}
