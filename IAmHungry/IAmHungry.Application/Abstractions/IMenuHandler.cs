using IAmHungry.Domain;

namespace IAmHungry.Application.Abstractions
{
    public interface IMenuHandler
    {
        string GetRestaurantInfoNode(string restaurantId, string infoPart);
        Restaurant GetRestaurant(string restaurantId);
        string GetMenuItemNode(string restaurantId, int trIndex, int tdIndex);
        MenuItem GetMenuItem(string restaurantId, int index);
        Menu GetMenu(string restaurantId);
        List<Restaurant> GetRestaurants();
    }
}
