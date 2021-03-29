using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class FoodModel
    {
        public long? Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Error{0}. name is invalid. It should be at most {1} and at least {2}")]
        public string Product { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Error{0}. name is invalid. It should be at most {1} and at least {2}")]
        public string description { get; set; }
    }
}
