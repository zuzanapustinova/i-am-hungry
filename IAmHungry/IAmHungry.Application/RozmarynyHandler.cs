using HtmlAgilityPack;
using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;

namespace IAmHungry.Application
{
    public class RozmarynyHandler : IRestaurantMenu
    {
        public IWebPageParser webPageParser { get; }

        private string _rozmarynyUrl;
        private string _rozmarynyKontakt;
        private string _rozmarynyMenu;
        private HtmlAgilityPack.HtmlDocument MenuPageContent { get; set; }

        public RozmarynyHandler(IWebPageParser parser, string url) 
        {
            //necessary to add /kontakt and /menu to get proper information
            webPageParser = parser;
            _rozmarynyUrl = url;
            _rozmarynyKontakt = $"{url}/kontakt";
            _rozmarynyMenu = $"{url}/menu";
            MenuPageContent = webPageParser.LoadPage(_rozmarynyMenu);
        }

        public Menu GetMenu(DateTime date)
        {
            var dailyMenu = new Menu();
            var dailyMenuNode = new List<HtmlNodeCollection>();
            var today = DateTime.Today;
            var day = (date == today) ? ConvertTodayToCzechDate() : ConvertToCzechDate(date);
            
            foreach (var node in webPageParser.FindNodes(MenuPageContent, $".//div[@class='dailyMenuMainGroup']"))
            {
                dailyMenuNode.AddRange(from node2 in node.ChildNodes where node2.InnerText.Contains(day) select node.ChildNodes);
            }

            foreach (var node in dailyMenuNode)
            {
                dailyMenu.Items.AddRange(
                    node
                        .Select(line => line.InnerText.Replace("\n", "").Replace("\t", ""))
                        .Where(text => !isEmpty(text))
                        .Select(text => new MenuItem(new Meal(text, true, new MealData(text).GetMeal().IsSoup )))
                );
            }

            return dailyMenu;
        }

        private static string ConvertTodayToCzechDate()
        {
            return DateTime.Today.Day + "." + DateTime.Today.Month + ".";
        }

        private static string ConvertToCzechDate(DateTime date)
        {
            return date.Day + "." + date.Month + ".";
        }

        public Restaurant GetRestaurant()
        {
            var webPage = webPageParser.LoadPage(_rozmarynyKontakt);
            var info = webPageParser.GetSingleNodeInnerText(webPage, "//div[@class='contactItem']//div[@class='headerTxt']").Split(", ");
            var restaurant = new Restaurant(_rozmarynyUrl, info[0], info[1])
            {
                //set to find menu for today
                DailyMenu = GetMenu(DateTime.Today)
               
            };
            if (restaurant.DailyMenu.Items.Count == 0)
            {
                restaurant.DailyMenu.Items.Add(new MenuItem(new Meal("Restaurace nedodala aktuální údaje.", false, false)));
            }
            return restaurant;
        }

        private bool isEmpty(string input)
        {
            string[] wrongChains = ["&nbsp;&nbsp;&nbsp;&nbsp;", " &nbsp;&nbsp;&nbsp;&nbsp;", "&nbsp;&nbsp;&nbsp;&nbsp; ", " &nbsp;&nbsp;&nbsp;&nbsp; ", "&nbsp;&nbsp;"
            ];
            return wrongChains.Contains(input);
        }
    }
}
