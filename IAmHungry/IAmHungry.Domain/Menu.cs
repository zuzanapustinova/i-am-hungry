namespace IAmHungry.Domain
{
    public class Menu 
    {
        private List<MenuItem>? _items;
        
        public List<MenuItem> Items 
        { 
            get
            {
                return _items ?? (_items = new List<MenuItem>());
            }
            set
            {
                _items = value;
            }
        }
        public int Count { get { return Items.Count; } }

        public Menu()
        {
        }

        public void Add(MenuItem item)
        {
            Items.Add(item);
        }       
    }
}
