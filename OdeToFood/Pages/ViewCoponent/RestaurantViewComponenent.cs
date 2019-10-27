using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.ViewCoponent
{
    public class RestaurantViewComponenent : ViewComponent
    {
        private IRestaurantData restaurantData;

        public RestaurantViewComponenent(IRestaurantData data)
        {
            this.restaurantData = data;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurant();
            return View(count);
        }
    }
}
