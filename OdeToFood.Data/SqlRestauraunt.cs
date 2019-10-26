using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestauraunt : IRestaurantData
    {
        private OdeToFoodDbContext db;

        public SqlRestauraunt(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();            
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);

            if (restaurant != null)
            {
                db.Restaurant.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return from r in db.Restaurant
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return db.Restaurant.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurant
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurant.Attach(updateRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updateRestaurant;
        }
    }
}
