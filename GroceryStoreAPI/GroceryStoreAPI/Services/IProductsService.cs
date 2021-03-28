using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    interface IProductsService
    {
        public IEnumerable<ProductModel> GetProducts(long foodId);
        public ProductModel GetProduct(long foodId, long candyId);
        public ProductModel CreateProduct(long foodId, ProductModel newCandy);
        public bool DeleteProduct(long foodId, long candyId);
        public ProductModel UpdateProduct(long foodId, long candyId, ProductModel updatedCandy);
    }
}
