using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class View
    {

        public void WriteMap(char [,] map) 
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
        }

        public void WriteSnake(char head,Position headPos, char [,] bodyMap) 
        {
            string text;

            for (int i = 0; i < bodyMap.GetLength(0); i++)
            {
                text = "";
                for (int j = 0; j < bodyMap.GetLength(1); j++)
                {

                    if (bodyMap[i, j] == default(char))
                    {
                        text += "  ";
                    }
                    else
                    {
                        text += $"{bodyMap[i, j]} ";
                    }
                    Console.SetCursorPosition(2, i + 1);
                    
                }
                Console.WriteLine(text);

            }

            Console.SetCursorPosition(headPos.PosX * 2, headPos.PosY);
            Console.Write(head);
        }

    }
}
