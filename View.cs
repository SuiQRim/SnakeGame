using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class View
    {
        public void WriteMap(Scene scene) 
        {
            for (int i = 0; i < scene.Map.GetLength(0); i++)
            {
                for (int j = 0; j < scene.Map.GetLength(1); j++)
                {

                    if (scene.Map[i, j] == default(char))
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(scene.Map[i, j] + " ");
                    }

                }
                Console.WriteLine();
            }
        }

    }
}
