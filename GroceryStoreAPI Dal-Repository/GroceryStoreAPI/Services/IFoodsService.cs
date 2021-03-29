using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public interface IFoodsService
    {
        public IEnumerable<FoodModel> GetFoods(string orderBy = "Id");
        public FoodWithProductModel GetFood(long foodId);
        public FoodModel CreateFood(FoodModel newFood);
        public bool DeleteFood(long foodId);
        public FoodModel UpdateFood(long foodId, FoodModel updatedFood);
    }
}
