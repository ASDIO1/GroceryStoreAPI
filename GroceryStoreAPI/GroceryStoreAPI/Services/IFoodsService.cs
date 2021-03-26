using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public interface IFoodsService
    {
        public IEnumerable<FoodModel> GetFoods();
        public FoodModel GetFood(long foodId);
        public FoodModel CreateFood(FoodModel newFood);
        public bool DeleteFood(long foodId);
    }
}
