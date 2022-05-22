namespace SnakeGame.Game
{
    internal class Position
    {
        public Position()
        {

        }

        public Position(Position position)
        {
            PosX = position.PosX;
            PosY = position.PosY;
        }
        public Position(int x, int y)
        {
            _posX = x;
            _posY = y;
        }
        private int _posX;
        private int _posY;

        public int PosX
        {
            get => _posX; 
            set => _posX = value; 
        }

        public int PosY
        {
            get => _posY; 
            set => _posY = value; 
        }

        public static bool operator ==(Position pos1, Position pos2) 
        {
            if (pos1._posY == pos2.PosY && pos1._posX == pos2.PosX) { return true; }
            return false;
        }
        public static bool operator != (Position pos1, Position pos2)
        {
            if (pos1._posY != pos2.PosY ^ pos1._posX != pos2.PosX) { return true; }
            return false;
        }

        public static Position operator +(Position pos1, int i)
        {
            return new Position(pos1.PosX + i, pos1.PosY + i);
        }
    }
}
