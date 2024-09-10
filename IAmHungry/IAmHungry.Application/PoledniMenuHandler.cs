using IAmHungry.Domain;
using System;

namespace IAmHungry.Application
{
    public class PoledniMenuHandler
    {
        private WebPageParser _parser;
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

        public PoledniMenuHandler(WebPageParser parser, string url = "https://www.olomouc.cz/poledni-menu/")
        {
            _parser = parser;
            _poledniMenuUrl = url;
            LoadedWebContent = _parser.LoadPage(_poledniMenuUrl);
        }
        
        public List<string> GetRestaurantIds()
        {
            var ids = new List<string>();
            var restaurantsIds = LoadedWebContent.DocumentNode.SelectNodes("//div[contains(concat(' ', normalize-space(@id), ' '), 'restMenu')]");
            foreach (var id in restaurantsIds)
            {
                ids.Add(id.Id);
            }
            return ids;
        }

        private string GetRestaurantInfoNode(string restaurantId, string infoPart)
        {
            string restaurantInfo = $"//div[@id='{restaurantId}']//div[@class='nazev-restaurace']/{infoPart}";
            return restaurantInfo;
        }

        public Restaurant GetRestaurantInfo(string restaurantId)
        {
            var restaurant = new Restaurant(restaurantId);
            var nodeName = GetRestaurantInfoNode(restaurantId, "/h3");
            var nodeAddress = GetRestaurantInfoNode(restaurantId, "/p[@class='restadresa']");

            var restaurantName = _parser.FindSingleNode(LoadedWebContent, nodeName);
            var restaurantAddress = _parser.FindSingleNode(LoadedWebContent, nodeAddress);


            if ((restaurantName != null) && (restaurantAddress != null)) 
            {
                restaurant.Name = restaurantName;
                restaurant.Address = restaurantAddress;
            }
            else
            {
                throw new ArgumentException("No restaurant name or address to display.");
            }
            return restaurant;
        }

        private string GetMenuItemNode(string restaurantId, int trIndex, int tdIndex)
        {
            string menuItemsNode = $"//div[@id='{restaurantId}']//table//tr[{trIndex}]/td[{tdIndex}]";
            return menuItemsNode;
        }

        private int GetItemsListCount(string restaurantId)
        {
            int count = 0;
            var itemsList = _parser.FindNodes(LoadedWebContent, $"//div[@id='{restaurantId}']//table/tr");
            if (itemsList != null)
            {
                count = itemsList.Count;
            }
            
            return count;
        }

        public MenuItem GetMenuItem(string restaurantId, int index)
        {
            var itemDescription = _parser.FindSingleNode(LoadedWebContent, GetMenuItemNode(restaurantId, index, 2));
            string itemPrice = _parser.FindSingleNode(LoadedWebContent, GetMenuItemNode(restaurantId, index, 3));

            var meal = new Meal("");
            
            if (itemDescription == GetMenuItemNode(restaurantId, index, 2))
            {
                meal.Description = "Restaurace nedodala aktuální údaje.";
                var actualMenuItem = new MenuItem(meal);
                return actualMenuItem;
            }
            else
            {
                meal.Description = itemDescription;
                if (itemPrice != "")
                {
                    int itemAmount = int.Parse(itemPrice.Split("&nbsp;")[0]);
                    var actualItemPrice = new Price(itemAmount);
                    var actualMenuItem = new MenuItem(meal, actualItemPrice);
                    return actualMenuItem;
                }
                else
                {
                    var actualMenuItem = new MenuItem(meal);
                    return actualMenuItem;
                }
            }   
        } 

        public Menu GetMenu(string restaurantId)
        {
            var menu = new Menu();
            var counter = GetItemsListCount(restaurantId);
            for (int i = 1; i <= counter; i++)
            {
                var item = GetMenuItem(restaurantId, i);
                menu.Add(item);
            }
            return menu;
        }       
    }
}
