using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByname(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
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
    }
}
