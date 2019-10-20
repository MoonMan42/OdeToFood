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
        IEnumerable<Restaurant> GetRestaurantByName(string name); 
        Restaurant GetRestaurantById(int Id); 
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

        

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   orderby r.Name
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }


        public Restaurant GetRestaurantById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);

        }

    }
}
