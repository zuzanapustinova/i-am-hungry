using IAmHungry.Domain;
using IAmHungry.Application.Abstractions;
namespace IAmHungry.Application;

public class RestaurantService
{
    public List<Restaurant> GetRestaurantList()
    {
        var restaurants = new List<Restaurant>();
        IWebPageParser parser = new WebPageParser();
        IPoledniMenuHandler poledniMenu = new PoledniMenuHandler(parser, "https://www.olomouc.cz/poledni-menu/");
        IRestaurantMenu rozmaryny = new RozmarynyHandler(parser, "https://rozmaryny.cz");
        //handle error if url does not exist 
        restaurants.Add(rozmaryny.GetRestaurant());
        restaurants.AddRange(poledniMenu.GetRestaurants());

        return restaurants;
    }

}