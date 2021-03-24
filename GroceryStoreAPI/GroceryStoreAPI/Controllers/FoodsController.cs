using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class FoodsController : Controller
    {
        static private IList<FoodModel> _foods = new List<FoodModel>() 
        {
            new FoodModel()
                {
                    Id = 1,
                    name = "Candy",
                    description = "A world of candies you cant even imagine"
                },
            new FoodModel()
            {
                Id = 2,
                name = "Meat",
                description = "Delicious meat for all tastes"
            }
        };

       /* public FoodsController()
        {
        }*/

        [HttpGet]
        public ActionResult<IEnumerable<FoodModel>> GetFoods()
        {
            return Ok(_foods);
        }

        [HttpGet("{foodId:long}")]
        public ActionResult<FoodModel> GetFood(long foodId)
        {
            var food = _foods.FirstOrDefault(f => f.Id == foodId);
            return Ok(food);
        }

        // POST   api/foods
        [HttpPost]
        public ActionResult<FoodModel> CreateFood([FromBody] FoodModel newFood)
        {
            var next_Id = _foods.OrderByDescending(f => f.Id).FirstOrDefault().Id + 1;
            newFood.Id = next_Id;
            _foods.Add(newFood);
            return Created($"api/foods/{next_Id}",newFood);
        }
    }
}
