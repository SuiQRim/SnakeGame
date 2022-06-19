using SnakeGame.Game;
using SnakeGame.GameData.Score;

namespace SnakeGame.MenuPrefab.MenuItems
{
    internal abstract class AMenuElement
    {
        public AMenuElement( Player player, ScoreObserver scoreObserver, string name)
        {
            _player = player;
            _name = name;
        }

        public const int MENUITEMMAXLENGTH = 16;

        public string _name;

        protected Player _player;

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
