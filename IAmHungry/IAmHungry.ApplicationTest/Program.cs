//Pouze pro potřeby testování. Tisk výstupů do konzole. 

using IAmHungry.Application;
using IAmHungry.Application.Abstractions;
using IAmHungry.Domain;
using System.Net.WebSockets;

namespace IAmHungry.ApplicationTest

{
    public class Program
    {
        static void Main(string[] args)
        {
            var parser = new WebPageParser();

            //var restaurants = new RestaurantService();
            //var restaurantsWithMenu = new List<Restaurant>();

            ////restaurace, které mají menu
            //foreach (var rest in restaurants.GetRestaurantList())
            //{
            //    foreach (var item in rest.DailyMenu.Items)
            //    {
            //        IMealData filter = new MealData(item.MealDescription);
            //        if (filter.IsEmpty()) continue;
            //        restaurantsWithMenu.Add(rest);
            //        break;
            //    }
            //}

            ////výpis těch, které mají vege menu
            //foreach (var restaurant in restaurantsWithMenu)
            //{
            //    Console.WriteLine(restaurant.Name);
            //    Console.WriteLine(restaurant.Address);
            //    Console.WriteLine();

            //    foreach (var item in restaurant.DailyMenu.Items)
            //    {
            //        IMealData filter = new MealData(item.MealDescription);
            //        if (!filter.IsVegetarian()) continue;
            //        Console.WriteLine(item.MealDescription.Description);
            //        if (item.MealPrice != null)
            //        {
            //            Console.WriteLine(item.MealPrice.ToString());
            //        }
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //IWebPageParser parser = new WebPageParser();
            //var rozmaryny = new RozmarynyHandler(parser, "https://rozmaryny.cz");
            //var rest = rozmaryny.GetRestaurant();
            //Console.WriteLine(rest.Name);
            //Console.WriteLine(rest.Address);
            //foreach (var item in rest.DailyMenu.Items)
            //{
            //    Console.WriteLine(item.MealDescription.Description);
            //}



            ////test funkcionality IPoledniMenuHandler a výstupní fce s použítím vege filtru
            //IWebPageParser parser = new WebPageParser();
            //IPoledniMenuHandler poledniPoledniMenu = new PoledniMenuHandler(parser);
            //var restaurants = poledniPoledniMenu.GetRestaurants();

            //foreach (var restaurant in restaurants)
            //{
            //    Console.WriteLine(restaurant.Name);
            //    Console.WriteLine(restaurant.Address);
            //    Console.WriteLine();

            //    foreach (var item in restaurant.DailyMenu.Items)
            //    {
            //        IMealData filter = new MealData(item.MealDescription);
            //        if (filter.IsVegetarian())
            //        {
            //            Console.WriteLine(item.MealDescription.Description);
            //            if (item.MealPrice != null)
            //            {
            //                Console.WriteLine(item.MealPrice.ToString());
            //            }
            //        }                   
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}


            /* test funkcionality PoledniMenuHandler
            IWebPageParser parser = new WebPageParser();
        var poledniPoledniMenu = new PoledniMenuHandler(parser);
        var restaurantsIds = poledniPoledniMenu.GetRestaurantIds();
        foreach (string id in restaurantsIds)
        {
            //vytiskne do konzole název restaurace a adresu, položky menu a cenu, pokud je k dispozici
            var restaurantInfo = poledniPoledniMenu.GetRestaurantInfo(id);
            Console.WriteLine(restaurantInfo.Name);
            Console.WriteLine(restaurantInfo.Address);

            var todaysMenu = poledniPoledniMenu.GetMenu(id);

            foreach(var item in  todaysMenu.Items)
            {
                Console.WriteLine(item.MealDescription.Description);
                if (item.MealPrice != null)
                {
                    Console.WriteLine(item.MealPrice.ToString());
                }

            }*/

            /*
           for (int i = 0; i < todaysMenu.Count; i++)
           {
               Console.WriteLine(todaysMenu.Items[i].MealDescription.Description);
               if (todaysMenu.Items[i].MealPrice != null)
               {
                   Console.WriteLine(todaysMenu.Items[i].MealPrice.ToString());
               }
           }
           Console.WriteLine();
       }*/

            /* test Parseru (vyhledávání konkrétních položek pomocí xpath)

            try
            {
                var page = parser.LoadPage("https://www.olomouc.cz/poledni-menu/");

                var menuItem1 = parser.GetSingleNodeInnerText(page, "//div[@id='restMenu30']//table/tr[1]/td[2]"); //první tr a druhý td, tedy popis jídla
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
                    Console.WriteLine(id.Url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
