using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetByName(string nameFragment);
        Restaurant Create(Restaurant newRestaurant);
        Restaurant Update(Restaurant updatedRestaurant);
        int SaveChanges();
    }
}
