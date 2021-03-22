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
        [HttpGet]
        public IEnumerable<string> GetFoods()
        {
            var foodList = new List<string>() { "Candy", "Fruits" };
            return foodList;
        }
    }
}
