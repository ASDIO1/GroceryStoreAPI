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

        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name"
        };

        //Estados de prueba del modelo
        public FoodsService()
        {
            _foods = new List<FoodModel>();

            _foods.Add(new FoodModel()
            {
                Id = 1,
                Name = "Candy",
                description = "A world of candies you cant even imagine"
            });
            _foods.Add(new FoodModel()
            {
                Id = 2,
                Name = "Meat",
                description = "Delicious meat for all tastes"
            });
        }

        //Endpoints desde el service
        public IEnumerable<FoodModel> GetFoods(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The orderBy value: {orderBy} is invalid, please use one of {String.Join(',',_allowedOrderByValues.ToArray())}");
            switch (orderBy.ToLower())
            {
                case "name":
                    return _foods.OrderBy(f => f.Name);
                default:
                    return _foods.OrderBy(f => f.Id);
            }
        }
        
        public FoodWithProductModel GetFood(long foodId)
        {
            var food = _foods.FirstOrDefault(f => f.Id == foodId);
            if (food == null)
            {
                throw new NotFoundItemException($"The food with id: {foodId} does not exist.");
            }
            var foodWithProducts = new FoodWithProductModel(food);
            //foodWithProducts.Products = //THIS IS BEEING FIXED with a repository to avoid Ciclic Dependency
            return foodWithProducts;
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

        public FoodModel UpdateFood(long foodId, FoodModel updatedFood)
        {
            updatedFood.Id = foodId;
            var food = GetFood(foodId);
            food.Name = updatedFood.Name ?? food.Name;
            food.description = updatedFood.description ?? food.description;
            return food;
        }
    }
}
