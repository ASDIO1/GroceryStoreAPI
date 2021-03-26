using GroceryStoreAPI.Exceptions;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Http;
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
            try
            {
                var foods = _foodsService.GetFoods();
                return Ok(foods);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpGet("{foodId:long}")]
        public ActionResult<FoodModel> GetFood(long foodId)
        {
            try
            {
                var food = _foodsService.GetFood(foodId);
                return Ok(food);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // POST   api/foods
        [HttpPost]
        public ActionResult<FoodModel> CreateFood([FromBody] FoodModel newFood)
        {
            try
            {
                if (!ModelState.IsValid)            //if invalid
                    return BadRequest(ModelState);

                var food = _foodsService.CreateFood(newFood);
                return Created($"api/foods/{food.Id}", food);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{foodId:long}")]
        public ActionResult<bool> DeleteFood(long foodId) 
        {
            try
            {
                var result = _foodsService.DeleteFood(foodId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
