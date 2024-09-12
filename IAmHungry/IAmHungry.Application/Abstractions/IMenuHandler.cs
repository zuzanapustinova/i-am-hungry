using IAmHungry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
