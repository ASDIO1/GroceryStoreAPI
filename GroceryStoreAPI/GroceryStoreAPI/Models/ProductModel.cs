﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double? Price { get; set; }
        public long FoodId { get; set; }
    }
}
