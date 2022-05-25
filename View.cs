using SnakeGame.SnakePrefab;
using SnakeGame.MenuPrefab.MenuItems;
using SnakeGame.Game;

namespace SnakeGame
{
    internal static class View
    {

        private const int TIME_VALUEMAXLENGTH = 8;
        private const int SCORE_VALUEMAXLENGTH = 4;

        private const string UIHORIZONTALBORDER = "——";
        private const string UIVERTICALBORDER = "||";
        private const string PIXEL = "██";

        private static object cursor = new();

        public static void StartConfigurate(Position _mapSize) 
        {
            WriteScoreBorder(_mapSize);
            WriteTimeBorder(_mapSize);
        }

        public static void WriteUnderMapWithSleep(string text, Position position)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 -  text.Length / 2, Console.WindowHeight / 2);
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }

        private static void WriteScoreBorder(Position mapSize) 
        {
            int mapHalfX = Console.WindowWidth / 2 - mapSize.PosX;
            int mapHalfY = Console.WindowHeight / 2 - mapSize.PosY / 2;
            Console.ForegroundColor = ConsoleColor.White;

            string text = "";
            for (int i = 0; i < SCORE_VALUEMAXLENGTH; i++)
            {
                text += $"{UIHORIZONTALBORDER}";
            }

            Console.SetCursorPosition(mapHalfX - 2, mapHalfY - 3);
            Console.WriteLine(text);

            Console.SetCursorPosition(mapHalfX - 2, mapHalfY - 2);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(mapHalfX + SCORE_VALUEMAXLENGTH , mapHalfY - 2);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(mapHalfX - 2, mapHalfY - 1);
            Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void WriteTimeBorder(Position mapSize) 
        {
            int mapHalfX = Console.WindowWidth / 2 - mapSize.PosX;
            int mapHalfY = Console.WindowHeight / 2 - mapSize.PosY / 2;

            Console.ForegroundColor = ConsoleColor.White;

            string text = "";

            for (int i = 0; i < TIME_VALUEMAXLENGTH - 2; i++)
            {
                text += $"{UIHORIZONTALBORDER}";
            }

            Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2 - TIME_VALUEMAXLENGTH - 2, mapHalfY - 3);
            Console.WriteLine(text);

            Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2, mapHalfY - 2);
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2 - TIME_VALUEMAXLENGTH - 2, mapHalfY - 2) ;
            Console.WriteLine(UIVERTICALBORDER);

            Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2 - TIME_VALUEMAXLENGTH - 2, mapHalfY - 1);
            Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public static void UpDataScore(int score, Position mapSize) 
        {
            int mapHalfY = Console.WindowHeight / 2 - mapSize.PosY / 2;
            lock (cursor) 
            {

                Console.ForegroundColor= ConsoleColor.Green;
                Console.SetCursorPosition(Console.WindowWidth / 2 - mapSize.PosX, mapHalfY - 2);
                Console.WriteLine($"{score,SCORE_VALUEMAXLENGTH - 1}");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }

        public static void UpDataLifeTime(TimeSpan timeSpan, Position mapSize) 
        {
            int mapHalfX = Console.WindowWidth / 2 - mapSize.PosX;
            int mapHalfY = Console.WindowHeight / 2 - mapSize.PosY / 2;

            lock (cursor)
            {
            
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2 - TIME_VALUEMAXLENGTH, mapSize.PosY - 1);
                Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}",timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));

                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public static void WriteMap(Point point, Position mapSize)
        {
            int mapHalfX = Console.WindowWidth / 2 - mapSize.PosX;
            int mapHalfY= Console.WindowHeight / 2 - mapSize.PosY / 2;

            lock (cursor)
            {
                
                Console.ForegroundColor = ConsoleColor.White;
                string text = "";
                for (int i = 0; i < mapSize.PosX * 2; i += 2)
                {
                    text += $"{PIXEL}";
                }

             
                for (int i = 0; i < mapSize.PosY + 2; i++)
                {
                    Console.SetCursorPosition(mapHalfX - 2, mapHalfY + i);
                    Console.Write($"{PIXEL}");
                    Console.SetCursorPosition(mapHalfX + mapSize.PosX * 2, mapHalfY + i);
                    Console.Write($"{PIXEL}");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(mapHalfX, mapHalfY);
                Console.WriteLine(text);

                Console.SetCursorPosition(mapHalfX, mapHalfY + mapSize.PosY + 1);
                Console.WriteLine(text);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(mapHalfX + (point.Position.PosX * 2), mapHalfY + point.Position.PosY + 1);
                Console.Write($"{PIXEL}");

                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

 

        public static void WriteSnake(List<Segment> bodyList, Position mapSize)
        {
            int mapHalfX = Console.WindowWidth / 2 - mapSize.PosX;
            int mapHalfY = Console.WindowHeight / 2 - mapSize.PosY / 2;
            Segment tail = bodyList.Last();

            lock (cursor)
            {
                Console.SetCursorPosition(mapHalfX + (tail.LastPosition.PosX * 2), mapHalfY + tail.LastPosition.PosY + 1);
                Console.Write("  ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(mapHalfX + (bodyList.First().Position.PosX * 2), mapHalfY + bodyList.First().Position.PosY + 1);

                Console.Write(bodyList.First());
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Segment segment in bodyList)
                {
                    if (segment.GetType() == typeof(Head)) continue;

                    Console.SetCursorPosition(mapHalfX + (segment.Position.PosX * 2), mapHalfY + segment.Position.PosY + 1);
                    Console.Write(segment);
                }

                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        private static void WriteAllMenuElement( List<AMenuElement> menuElements, bool needToClear)
        {

            Console.ForegroundColor = ConsoleColor.White;
            int margin = 0;

            foreach (var menuElement in menuElements)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - menuElement.CenterLength, 
                    Console.WindowHeight / 2  + margin);
                margin += 2;
                Console.Write(menuElement);

            }
            Console.ForegroundColor = ConsoleColor.Black;
        }


        public static void WriteMenuInfoWindow(List<string> text, ConsoleColor color) 
        {
            Console.Clear();
            Console.ForegroundColor = color;
            int margin = 8;
            foreach (string item in text)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - item.Length / 2, margin);
                margin += 2;
                Console.Write(item);
            }
        }


        public static void WriteSelectedMenuElement(List<AMenuElement> menuElements, int index, bool needToClear)
        {
            WriteAllMenuElement( menuElements, needToClear);

            Console.ForegroundColor = ConsoleColor.Green;
            int margin = 2 * index;
            Console.SetCursorPosition(Console.WindowWidth / 2 - menuElements[index].CenterLength,
                Console.WindowHeight / 2  + margin);
            Console.Write(menuElements[index]);

            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}
