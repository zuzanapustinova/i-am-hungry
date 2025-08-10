using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class PoledniMenuHandler : IPoledniMenuHandler
    {
        private IWebPageParser _parser;
        private string _poledniMenuUrl;
        private HtmlAgilityPack.HtmlDocument LoadedWebContent { get; set; }
        
        public string poledniMenuUrl
        {
            get 
            { 
                return _poledniMenuUrl; 
            }
            set
            {
                _poledniMenuUrl = value;
            }
        }

        public PoledniMenuHandler(IWebPageParser parser, string url)
        {
            _parser = parser;
            _poledniMenuUrl = url;
            LoadedWebContent = _parser.LoadPage(_poledniMenuUrl);
        }
        
        public List<string> GetRestaurantIds()
        {
            var restaurantsIds = LoadedWebContent.DocumentNode.SelectNodes("//div[contains(concat(' ', normalize-space(@id), ' '), 'restMenu')]");
            return restaurantsIds.Select(id => id.Id).ToList();
        }

        public string GetRestaurantInfoNode(string restaurantId, string infoPart)
        {
            var restaurantInfo = $"//div[@id='{restaurantId}']//div[@class='nazev-restaurace']/{infoPart}";
            return restaurantInfo;
        }

        public Restaurant GetRestaurant(string restaurantId)
        {
            var nodeName = GetRestaurantInfoNode(restaurantId, "/h3");
            var nodeAddress = GetRestaurantInfoNode(restaurantId, "/p[@class='restadresa']");

            var restaurantName = _parser.GetSingleNodeInnerText(LoadedWebContent, nodeName);
            var restaurantAddress = _parser.GetSingleNodeInnerText(LoadedWebContent, nodeAddress);

            if ((restaurantName != null) && (restaurantAddress != null)) 
            {
                return new Restaurant(restaurantId, restaurantName, restaurantAddress);
            }
            else
            {
                return new Restaurant(restaurantId, "Jméno restaurace neuvedeno", "Adresa restaurace neuvedena");
            }
        }

        public string GetMenuItemNode(string restaurantId, int trIndex, int tdIndex)
        {
            var menuItemsNode = $"//div[@id='{restaurantId}']//table//tr[{trIndex}]/td[{tdIndex}]";
            return menuItemsNode;
        }

        private int GetItemsListCount(string restaurantId)
        {
            var itemsList = _parser.GetNodesInnerText(LoadedWebContent, $"//div[@id='{restaurantId}']//table/tr");
            return (itemsList != null) ? itemsList.Count : 0;
        }

        public MenuItem GetMenuItem(string restaurantId, int index)
        {
            var itemDescription = _parser.GetSingleNodeInnerText(LoadedWebContent, GetMenuItemNode(restaurantId, index, 2));
            var itemPrice = _parser.GetSingleNodeInnerText(LoadedWebContent, GetMenuItemNode(restaurantId, index, 3));
            if (itemDescription == GetMenuItemNode(restaurantId, index, 2))
            {
                var meal = new Meal("Restaurace nedodala aktuální údaje.", false, false);
                return new MenuItem(meal);
            }
            else
            {
                var mealData = new MealData(itemDescription).GetMeal();
                if (itemPrice != "")
                {
                    var itemAmount = int.Parse(itemPrice.Split("&nbsp;")[0]);
                    var actualItemPrice = new Price(itemAmount);
                    return new MenuItem(mealData, actualItemPrice);
                }
                else
                {
                    return new MenuItem(mealData);
                }
            }   
        } 

        public Menu GetMenu(string restaurantId)
        {
            var menu = new Menu();
            var counter = GetItemsListCount(restaurantId);
            for (var i = 1; i <= counter; i++)
            {
                var item = GetMenuItem(restaurantId, i);
                menu.Items.Add(item);
            }
            return menu;
        }

        public List<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>();
            var restaurantsIds = GetRestaurantIds();
            foreach (var id in restaurantsIds)
            {
                var restaurant = GetRestaurant(id);
                restaurants.Add(restaurant);
                var todaysMenu = GetMenu(id);
                restaurant.DailyMenu = todaysMenu;
            }
            return restaurants;
        }
    }
}
