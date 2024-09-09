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

        public List<string> GetRestaurantInfo(string restaurantId)
        {
            var restaurantInfo = new List<string>();
            var nodeName = GetRestaurantInfoNode(restaurantId, "/h3");
            var nodeAddress = GetRestaurantInfoNode(restaurantId, "/p[@class='restadresa']");

            var restaurantName = _parser.FindSingleNode(LoadedWebContent, nodeName);
            var restaurantAddress = _parser.FindSingleNode(LoadedWebContent, nodeAddress);


            if ((restaurantName != null) && (restaurantAddress != null)) 
            {
                restaurantInfo.Add(restaurantName);
                restaurantInfo.Add(restaurantAddress);
            }
            else
            {
                throw new ArgumentException("No restaurant name or address to display.");
            }
            return restaurantInfo;
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

        private List<string> GetMenuItem(string restaurantId, int index)
        {
            var itemDescription = _parser.FindSingleNode(LoadedWebContent, GetMenuItemNode(restaurantId, index, 2));
            var itemPrice = _parser.FindSingleNode(LoadedWebContent, GetMenuItemNode(restaurantId, index, 3));
            var menuItem = new List<string>();
            if (itemDescription == GetMenuItemNode(restaurantId, index, 2))
            {
                menuItem.Add("Restaurace nedodala aktuální údaje.");
                return menuItem;
            }
            menuItem.Add(itemDescription);
            menuItem.Add(itemPrice.Replace("&nbsp;", " ")); //zbavení se pevné mezery, později rozdělit na částku a měnu
            return menuItem;
        } 

        public List<List<string>> GetMenuItems(string restaurantId)
        {
            var menuItems = new List<List<string>>();
            var counter = GetItemsListCount(restaurantId);
            
            for (int i = 1; i <= counter; i++)
            {
                var item = GetMenuItem(restaurantId, i);
                menuItems.Add(item);
            }
            return menuItems;
        }
    }
}
