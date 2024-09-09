//Pouze pro potřeby testování. Tisk výstupů do konzole. 

using IAmHungry.Application;
using IAmHungry.Domain;

namespace Test

{
    public class Program
    {
        static void Main(string[] args)
        {
            var price = new Price(157, "eur");

            var meal = new Meal("vegetarian: Smažený květák", "tofu");
            /*
            if (meal.NameContains)
            {
                Console.WriteLine(meal.Name);
            }
            else
            {
                Console.WriteLine("no such meal");
            }*/

            var menuItem = new MenuItem(meal, price);
            //Console.WriteLine(menuItem.MealDescription.Name.ToString() + " " + menuItem.MealPrice.ToString());

            var parser = new WebPageParser();

            /*
            try
            {
                var page = parser.LoadPage("https://www.olomouc.cz/poledni-menu/");

                var menuItem1 = parser.FindSingleNode(page, "//div[@id='restMenu30']//table/tr[1]/td[2]"); //první tr a druhý td, tedy popis jídla 
                Console.WriteLine(menuItem1);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/

            var menu = new PoledniMenuHandler(parser);
           

            /*
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

            /*
            try
            {
                var restaurantsIds = menu.GetRestaurantIds();
                foreach (string id in restaurantsIds)
                {
                    Console.WriteLine(id);
                    var menuItems = menu.GetMenuItems(id);
                    foreach (var item in menuItems)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }*/

            /*
            try
            {    
                var restaurantsIds = menu.GetRestaurantIds();
                foreach (string id in restaurantsIds)
                {
                    Console.WriteLine(id);
                    var restaurantInfo = menu.GetRestaurantInfo(id);
                    foreach (var item in restaurantInfo)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }*/

            
            var restaurantsIds = menu.GetRestaurantIds();
            foreach (string id in restaurantsIds)
            {
                Console.WriteLine(id);
                var menus = menu.GetMenuItems(id);
                foreach(var item in menus)
                {
                   
                    foreach (var food in item)
                    {
                        Console.WriteLine(food);
                    }   
                }
                Console.WriteLine();
            }
        }
    }
}
