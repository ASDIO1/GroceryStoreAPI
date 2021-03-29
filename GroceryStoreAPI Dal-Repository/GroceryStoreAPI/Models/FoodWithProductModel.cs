using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class FoodWithProductModel : FoodModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public FoodWithProductModel(FoodModel food)
        {
            this.Name = food.Name;
            this.description = food.description;
        }
    }
}
