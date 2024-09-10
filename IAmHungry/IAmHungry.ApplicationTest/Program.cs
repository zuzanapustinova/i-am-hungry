//Pouze pro potřeby testování. Tisk výstupů do konzole. 

using IAmHungry.Application;
using IAmHungry.Domain;

namespace IAmHungry.ApplicationTest

{
    public class Program
    {
        static void Main(string[] args)
        {
            // test funkcionality PoledniMenuHandler
            var parser = new WebPageParser();
            var poledniMenu = new PoledniMenuHandler(parser);
            var restaurantsIds = poledniMenu.GetRestaurantIds();
            foreach (string id in restaurantsIds)
            {
                //vytiskne do konzole název restaurace a adresu, položky menu a cenu, pokud je k dispozici
                var restaurantInfo = poledniMenu.GetRestaurantInfo(id);
                Console.WriteLine(restaurantInfo.Name);
                Console.WriteLine(restaurantInfo.Address);

                var todaysMenu = poledniMenu.GetMenu(id);
                var numberOfItems = todaysMenu.Count;
                for (int i = 0; i < numberOfItems; i++)
                {
                    Console.WriteLine(todaysMenu.Items[i].MealDescription.Description);
                    if (todaysMenu.Items[i].MealPrice != null)
                    {
                        Console.WriteLine(todaysMenu.Items[i].MealPrice.ToString());
                    }
                }
                Console.WriteLine();
            }

            /* test Parseru (vyhledávání konkrétních položek pomocí xpath)
            
            try
            {
                var page = parser.LoadPage("https://www.olomouc.cz/poledni-menu/");

                var menuItem1 = parser.FindSingleNode(page, "//div[@id='restMenu30']//table/tr[1]/td[2]"); //první tr a druhý td, tedy popis jídla 
                Console.WriteLine(menuItem1);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var page = parser.LoadPage("https://www.olomouc.cz/poledni-menu/");
                var restaurantIds = page.DocumentNode.SelectNodes("//div[contains(concat(' ', normalize-space(@id), ' '), 'restMenu')]");
                foreach (var id in  restaurantIds) 
                {
                    Console.WriteLine(id.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
