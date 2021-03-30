using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Error{0}. name is invalid. It should be at most {1} and at least {2}")]
        public string Type { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Error{0}. name is invalid. It should be at most {1} and at least {2}")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Error{0}. name is invalid. It should be at most {1} and at least {2}")]
        public string Brand { get; set; }
        [Required]
        [Range(0.1,100000)]
        public double? Price { get; set; }
        [Range(0, 0.99,ErrorMessage = "Error{0}. discount is invalid. It should be in the range of {1} to {2} percent")]
        public double? Discount { get; set; } = 0;
        public long FoodId { get; set; }
    }
}
