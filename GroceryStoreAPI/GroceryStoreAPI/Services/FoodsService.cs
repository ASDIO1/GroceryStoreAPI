using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class FoodsService : IFoodsService
    {
        public FoodModel CreateFood(FoodModel newFood)
        {
            throw new NotImplementedException();
        }

        public FoodModel GetFood(long foodId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FoodModel> GetFoods()
        {
            throw new NotImplementedException();
        }
    }
}
