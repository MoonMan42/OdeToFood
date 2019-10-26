using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{

    // installed entityframeworkcore and entityframeworkcore.design, entityframeworkcore.sql in NuGet packages (v2.1.4)

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants(); 
        IEnumerable<Restaurant> GetRestaurantByName(string name); 
        Restaurant GetRestaurantById(int Id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();

    }
}
