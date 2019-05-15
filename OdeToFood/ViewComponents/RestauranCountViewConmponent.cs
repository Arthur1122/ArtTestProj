using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestauranCountViewConmponent : ViewComponent
    {
        private readonly IRestaurantData restauranData;

        public RestauranCountViewConmponent(IRestaurantData restauranData)
        {
            this.restauranData = restauranData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restauranData.GetCountOfRestaurants();
            return View(count);
        }

    }
}
