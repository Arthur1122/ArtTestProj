using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByname(string name);
        Restaurant GetById(int id);

    }

    public class InMemoryrestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryrestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Scot's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant {Id = 2, Name = "Cinamon Club", Location = "London", Cuisine = CuisineType.Mexican },
                new Restaurant{ Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id==id);

        }
        public IEnumerable<Restaurant> GetRestaurantsByname(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
