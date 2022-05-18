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

    }
}
