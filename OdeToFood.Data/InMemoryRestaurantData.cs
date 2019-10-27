using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurant()
        {
            return restaurants.Count();
        }
    }
}
