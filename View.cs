using SnakeGame.SnakePrefab;
using SnakeGame.Menu.MenuItems;
using SnakeGame.Game;

namespace SnakeGame
{
    internal static class View
    {
        private const int MAP_TOP_MARGIN = 5;
        private const int MAP_LEFT_MARGIN = 10;

        private const int TOP_PADDING = 2;
        private const int LEFT_PADDING = 2;

        private const int TIME_TOP_MARGIN = 3;
        private const int TIME_LEFT_MARGIN = 8;
        private const int TIME_VALUEMAXLENGTH = 8;

        private const int SCORE_TOP_MARGIN = 3;
        private const int SCORE_LEFT_MARGIN = TIME_LEFT_MARGIN + (TIME_VALUEMAXLENGTH * 2) + 2;
        private const int SCORE_VALUEMAXLENGTH = 4;

        private const string UIHORIZONTALBORDER = "——";
        private const string UIVERTICALBORDER = "||";
        private const string VERTICALBORDER = "██";
        private const string HORIZONTALBORDER = "██";
        private const string POINT = "██";

        private static object cursor = new();

        public static void StartConfigurate() 
        {
            Console.Clear();
            WriteScoreBorder();
            WriteTimeBorder();
        }

        private static void WriteScoreBorder() 
        {
            Console.ForegroundColor = ConsoleColor.White;

            string text = "";
            for (int i = 0; i < SCORE_VALUEMAXLENGTH; i++)
            {
                text += $"{UIHORIZONTALBORDER}";
            }

            Console.SetCursorPosition(SCORE_LEFT_MARGIN, SCORE_TOP_MARGIN - 1);
            Console.WriteLine(text);

            Console.SetCursorPosition(SCORE_LEFT_MARGIN, SCORE_TOP_MARGIN);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(SCORE_LEFT_MARGIN + (SCORE_VALUEMAXLENGTH * 2) - 2, SCORE_TOP_MARGIN);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(SCORE_LEFT_MARGIN, SCORE_TOP_MARGIN + 1);
            Console.WriteLine(text);

        }

        private static void  WriteTimeBorder() 
        {
            Console.ForegroundColor = ConsoleColor.White;

            string text = "";

            for (int i = 0; i < TIME_VALUEMAXLENGTH; i++)
            {
                text += $"{UIHORIZONTALBORDER}";
            }

            Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN - 1);
            Console.WriteLine(text);

            Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(TIME_LEFT_MARGIN + (TIME_VALUEMAXLENGTH * 2) - 2, TIME_TOP_MARGIN);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(TIME_LEFT_MARGIN, TIME_TOP_MARGIN + 1);
            Console.WriteLine(text);

        }

        public static void UpDataScore(int score) 
        {
            lock (cursor) 
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.SetCursorPosition(SCORE_LEFT_MARGIN + LEFT_PADDING, SCORE_TOP_MARGIN);
                Console.WriteLine($"{score,SCORE_VALUEMAXLENGTH - 1}");
            }
        }

        public static void UpDataLifeTime(TimeSpan timeSpan) 
        {
            lock (cursor)
            {
             

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition( TIME_LEFT_MARGIN + LEFT_PADDING, TIME_TOP_MARGIN);
                Console.WriteLine(timeSpan);
            }
        }

        public static void WriteMap(Point point, Position mapSize)
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
                    Console.SetCursorPosition(MAP_LEFT_MARGIN - LEFT_PADDING, MAP_TOP_MARGIN + i);
                    Console.Write($"{VERTICALBORDER}");
                    Console.SetCursorPosition(MAP_LEFT_MARGIN + LEFT_PADDING + (mapSize.PosX * 2) - 2, MAP_TOP_MARGIN + i);
                    Console.Write($"{VERTICALBORDER}");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(MAP_LEFT_MARGIN + (point.Position.PosX * 2), MAP_TOP_MARGIN + point.Position.PosY + 1);
                Console.Write($"{POINT}");
            }
        }

 

        public static void WriteSnake(List<Segment> bodyList)
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

        public static void WriteAllMenuElement(int leftMargin, int topMargin, List<MenuElement> menuElements)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int margin = 0;

            foreach (var menuElement in menuElements)
            {
                Console.SetCursorPosition(leftMargin + MenuElement.MENUITEMMAXLENGTH - menuElement.CenterLength, topMargin + margin);
                margin += 2;
                Console.Write(menuElement);

            }
        }
        public static void WriteSelectedMenuElement(int leftMargin, int topMargin, List<MenuElement> menuElements, int index)
        {
            WriteAllMenuElement(leftMargin, topMargin, menuElements);

            Console.ForegroundColor = ConsoleColor.Green;
            int margin = 2 * index;
            Console.SetCursorPosition(leftMargin + MenuElement.MENUITEMMAXLENGTH - menuElements[index].CenterLength, topMargin + margin);
            Console.Write(menuElements[index]);

            
        }

    }
}
