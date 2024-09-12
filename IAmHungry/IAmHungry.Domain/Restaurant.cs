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

        public Restaurant(string id)
        {
            Id = id;
        }

        public void AddMenu(Menu menu)
        {
            DailyMenu = menu;
        }
    }
}
