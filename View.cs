using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.SnakePrefab;

namespace SnakeGame
{
    internal static  class View
    {

        private const int TOP_MARGIN = 5;
        private const int LEFT_MARGIN = 10;
        private const int TOP_BORDERPADDING = 2;
        private const int LEFT_BORDERPADDING = 2;
        private const string VERTICALBORDER = "██";
        private const string HORIZONTALBORDER = "██";
        private const string POINT = "██";

        public static void WriteMap(Point point, Position MaxPos)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string text = "";
            for (int i = 0; i < MaxPos.PosX * 2; i += 2)
            {
                text += $"{HORIZONTALBORDER}";
            }

            Console.SetCursorPosition(LEFT_MARGIN, TOP_MARGIN);
            Console.WriteLine(text);

            Console.SetCursorPosition(LEFT_MARGIN, TOP_MARGIN + MaxPos.PosY);
            Console.WriteLine(text);


            for (int i = 0; i < MaxPos.PosX + 1; i++)
            {
                Console.SetCursorPosition(LEFT_MARGIN - LEFT_BORDERPADDING, TOP_MARGIN + i);
                Console.Write($"{VERTICALBORDER}");
                Console.SetCursorPosition(LEFT_MARGIN + LEFT_BORDERPADDING + (MaxPos.PosX * 2) - 2, TOP_MARGIN + i);
                Console.Write($"{VERTICALBORDER}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(LEFT_MARGIN + (point.Position.PosX * 2), TOP_MARGIN + point.Position.PosY + 1);
            Console.Write($"{POINT}");
        }

        public static void WriteSnake(List<Segment> bodyList) 
        {


            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(LEFT_MARGIN + (bodyList[0].Position.PosX * 2), TOP_MARGIN + bodyList[0].Position.PosY + 1);
            
            Console.Write(bodyList[0]);
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (Segment segment in bodyList)
            {
                if (segment.GetType() == typeof(Head)) continue;

                Console.SetCursorPosition( LEFT_MARGIN + (segment.Position.PosX * 2), TOP_MARGIN +  segment.Position.PosY + 1);
                Console.Write(segment);
            }

        }

    }
}
