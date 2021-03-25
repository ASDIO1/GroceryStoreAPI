using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
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

        private IFoodsService _foodsService;
        public FoodsController(IFoodsService foodsService)
        {
            _foodsService = foodsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FoodModel>> GetFoods()
        {
            var foods = _foodsService.GetFoods();
            return Ok(foods);
        }

        [HttpGet("{foodId:long}")]
        public ActionResult<FoodModel> GetFood(long foodId)
        {
            var food = _foodsService.GetFood(foodId);
            return Ok(food);
        }

        // POST   api/foods
        [HttpPost]
        public ActionResult<FoodModel> CreateFood([FromBody] FoodModel newFood)
        {
            var food = _foodsService.CreateFood(newFood);
            return Created($"api/foods/{food.Id}",food);
        }
    }
}
