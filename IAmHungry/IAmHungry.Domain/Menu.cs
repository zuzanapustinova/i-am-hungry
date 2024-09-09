namespace IAmHungry.Domain
{
    public class Menu
    {
        private int _id;
        private List<MenuItem> _items;
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public List<MenuItem> Items
        {
            get
            {
                return _items;
            }
        }

        public Menu()
        {
        }
    }
}
