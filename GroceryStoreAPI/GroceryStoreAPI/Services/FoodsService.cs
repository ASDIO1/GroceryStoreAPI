using GroceryStoreAPI.Exceptions;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class FoodsService : IFoodsService
    {
        //ESTADOS del modelo
        static private IList<FoodModel> _foods;

        public FoodsService()
        {
            _foods = new List<FoodModel>();

            _foods.Add(new FoodModel()
            {
                Id = 1,
                name = "Candy",
                description = "A world of candies you cant even imagine"
            });
            _foods.Add(new FoodModel()
            {
                Id = 2,
                name = "Meat",
                description = "Delicious meat for all tastes"
            });
        }

        //Endpoints desde el service
        public IEnumerable<FoodModel> GetFoods()
        {
            return _foods;
        }
        
        public FoodModel GetFood(long foodId)
        {
            var food = _foods.FirstOrDefault(f => f.Id == foodId);
            if (food == null)
            {
                throw new NotFoundItemException($"The team with id: {foodId} does not exist.");
            }
            return food;
        }
        public FoodModel CreateFood(FoodModel newFood)
        {
            var next_Id = _foods.OrderByDescending(f => f.Id).FirstOrDefault().Id + 1;
            newFood.Id = next_Id;
            _foods.Add(newFood);
            return newFood;
        }

        public bool DeleteFood(long foodId)
        {
            var foodToDelete = GetFood(foodId);
            _foods.Remove(foodToDelete);
            return true;
        }
    }
}
