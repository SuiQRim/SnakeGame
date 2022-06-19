using SnakeGame.Game;
using SnakeGame.DataBase.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal abstract class AMenuElement
    {
        public AMenuElement( Player player, IScoreController scoreObserver, string name)
        {
            _player = player;
            _scoreObserver = scoreObserver;
            _name = name;
        }

        public const int MENUITEMMAXLENGTH = 16;

        public string _name;

        protected Player _player;

        protected IScoreController _scoreObserver;

        public int Length
        {
            get => _name.Length;
        }
        public int CenterLength 
        {
            get => _name.Length / 2;
        } 

        public abstract Menu Do();
        public override string ToString() => _name;

    }
}
