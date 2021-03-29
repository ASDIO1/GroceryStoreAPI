using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Data.Entities
{
    public class FoodEntity
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}
