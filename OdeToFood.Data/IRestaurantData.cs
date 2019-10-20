using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants(); 
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Scott\'s Pizza", Location="Atlanta", Cuisine=CuisineType.Itilian},
                new Restaurant{Id=2, Name="Aladin\'s", Location="Cicago", Cuisine=CuisineType.Indian},
                new Restaurant{Id=3, Name="Altons", Location="Dallas", Cuisine=CuisineType.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return from r in restaurants orderby r.Name select r;
        }
    }
}
