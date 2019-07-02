using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantRepository()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Scott's Pizza",
                    Location = "Maryland",
                    Cuisine = CuisineType.Italian
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Taco Anders",
                    Location = "Witney",
                    Cuisine = CuisineType.Mexican
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Crispy Duck 2",
                    Location = "Didcot",
                    Cuisine = CuisineType.Chinese
                },
            };
        }

        public Restaurant GetById(int id)
        {
            return _restaurants
                        .SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public IEnumerable<Restaurant> GetByName(string nameFragment)
        {
            return _restaurants
                        .Where(r => string.IsNullOrEmpty(nameFragment) || r.Name.StartsWith(nameFragment, StringComparison.InvariantCultureIgnoreCase));
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;

            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant == null)
                throw new ArgumentException($"Restaurant not found with id {updatedRestaurant.Id}", nameof(updatedRestaurant));

            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }

        public int SaveChanges()
        {
            return 0; // n/a for in-memory implementation
        }
    }
}
