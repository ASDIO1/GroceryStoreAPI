using GroceryStoreAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Data.Repositories
{
    public interface IGroceryStoreRepository
    {
        //FOODS
        public IEnumerable<FoodEntity> GetFoods(string orderBy = "Id");
        public FoodEntity GetFood(long foodId);
        public FoodEntity CreateFood(FoodEntity newFood);
        public bool DeleteFood(long foodId);
        public FoodEntity UpdateFood(long foodId, FoodEntity updatedFood);
        //PRODUCTS
        public IEnumerable<ProductEntity> GetProducts(long foodId);
        public ProductEntity GetProduct(long foodId, long candyId);
        public ProductEntity CreateProduct(long foodId, ProductEntity newCandy);
        public bool DeleteProduct(long foodId, long candyId);
        public ProductEntity UpdateProduct(long foodId, long candyId, ProductEntity updatedCandy);
    }
}
