namespace IAmHungry.Domain
{

    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        private Menu? _dailyMenu;
        public Menu DailyMenu {
            get 
            {
                { return _dailyMenu ?? (_dailyMenu = new Menu()); }
            }
            set 
            { 
                _dailyMenu = value; 
            }
        }

        public Restaurant(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }      
    }
}
