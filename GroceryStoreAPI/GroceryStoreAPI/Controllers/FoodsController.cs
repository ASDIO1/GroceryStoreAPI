using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/foods")]
    public class FoodsController : Controller
    {
        private IList<FoodModel> _foods;

        public FoodsController()
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

        [HttpGet]
        public IEnumerable<FoodModel> GetFoods()
        {
            return _foods;
        }
    }
}
