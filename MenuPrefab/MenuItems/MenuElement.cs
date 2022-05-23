namespace SnakeGame.MenuPrefab.MenuItems
{
    internal abstract class MenuElement
    {
        public MenuElement(string name)
        {
            _name = name;
        }
        public const int MENUITEMMAXLENGTH = 16;

        public string _name;

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
