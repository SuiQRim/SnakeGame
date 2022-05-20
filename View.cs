using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.SnakePrefab;

namespace SnakeGame
{
    internal class View
    {

        private const int MAP_TOP_MARGIN = 5;
        private const int MAP_LEFT_MARGIN = 10;
        private const int MAP_TOP_PADDING = 2;
        private const int MAP_LEFT_PADDING = 2;

        private const int TIME_TOP_MARGIN = 3;
        private const int TIME_LEFT_MARGIN = 8;

        private const string UIHORIZONTALBORDER = "==";
        private const string UIVERTICALBORDER = "‖‖";
        private const string VERTICALBORDER = "██";
        private const string HORIZONTALBORDER = "██";
        private const string POINT = "██";

        private object cursor = new();

        public void WriteLifeTime(TimeSpan timeSpan) 
        {
            lock (cursor)
            {
                Console.ForegroundColor = ConsoleColor.White;
                int length = timeSpan.ToString().Length;

                string text = "";

                for (int i = 0; i < length; i++)
                {
                    text += $"{UIHORIZONTALBORDER}";
                }

                Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN - 1);
                Console.WriteLine(text);

                Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN);
                Console.WriteLine(UIVERTICALBORDER);
                Console.SetCursorPosition(TIME_LEFT_MARGIN + (length * 2) - 2, TIME_TOP_MARGIN);
                Console.WriteLine(UIVERTICALBORDER);
                Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN + 1);
                Console.WriteLine(text);

                
                Console.SetCursorPosition( TIME_LEFT_MARGIN + MAP_LEFT_PADDING, TIME_TOP_MARGIN);
                Console.WriteLine(timeSpan);
            }
        }

        public void WriteMap(Point point, Position mapSize)
        {
            lock (cursor)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string text = "";
                for (int i = 0; i < mapSize.PosX * 2; i += 2)
                {
                    text += $"{HORIZONTALBORDER}";
                }

                Console.SetCursorPosition(MAP_LEFT_MARGIN, MAP_TOP_MARGIN);
                Console.WriteLine(text);

                Console.SetCursorPosition(MAP_LEFT_MARGIN, MAP_TOP_MARGIN + mapSize.PosY);
                Console.WriteLine(text);


                for (int i = 0; i < mapSize.PosX + 1; i++)
                {
                    Console.SetCursorPosition(MAP_LEFT_MARGIN - MAP_LEFT_PADDING, MAP_TOP_MARGIN + i);
                    Console.Write($"{VERTICALBORDER}");
                    Console.SetCursorPosition(MAP_LEFT_MARGIN + MAP_LEFT_PADDING + (mapSize.PosX * 2) - 2, MAP_TOP_MARGIN + i);
                    Console.Write($"{VERTICALBORDER}");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(MAP_LEFT_MARGIN + (point.Position.PosX * 2), MAP_TOP_MARGIN + point.Position.PosY + 1);
                Console.Write($"{POINT}");
            }
        }

 

        public void WriteSnake(List<Segment> bodyList)
        {
            lock (cursor)
            {
                Segment tail = bodyList.Last();

                Console.SetCursorPosition(MAP_LEFT_MARGIN + (tail.LastPosition.PosX * 2), MAP_TOP_MARGIN + tail.LastPosition.PosY + 1);
                Console.Write("  ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(MAP_LEFT_MARGIN + (bodyList.First().Position.PosX * 2), MAP_TOP_MARGIN + bodyList.First().Position.PosY + 1);

                Console.Write(bodyList.First());
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Segment segment in bodyList)
                {
                    if (segment.GetType() == typeof(Head)) continue;

                    Console.SetCursorPosition(MAP_LEFT_MARGIN + (segment.Position.PosX * 2), MAP_TOP_MARGIN + segment.Position.PosY + 1);
                    Console.Write(segment);
                }
            }
        }

    }
}
