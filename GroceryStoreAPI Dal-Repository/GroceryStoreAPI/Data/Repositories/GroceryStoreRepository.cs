using GroceryStoreAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Data.Repositories
{
    public class GroceryStoreRepository : IGroceryStoreRepository
    {
        private List<FoodEntity> _foods;
        private List<ProductEntity> _products;

        public GroceryStoreRepository()
        {
            _foods = new List<FoodEntity>();
            _products = new List<ProductEntity>();
            //FOODS
            _foods.Add(new FoodEntity()
            {
                Id = 1,
                Name = "Candy",
                description = "A world of candies you cant even imagine"
            });
            _foods.Add(new FoodEntity()
            {
                Id = 2,
                Name = "Meat",
                description = "Delicious meat for all tastes"
            });
            //PRODUCTS
            _products.Add(new ProductEntity()
            {
                Id = 1,
                Type = "Chocolate",
                Name = "Sublime",
                Brand = "Nestle",
                Price = 2,
                FoodId = 1 //FoodModel with "Candy" name
            });
            _products.Add(new ProductEntity()
            {
                Id = 2,
                Type = "Gummies",
                Name = "Cerebritos",
                Brand = "Mogul",
                Price = 2.50,
                FoodId = 1 //FoodModel with "Candy" name
            });
            _products.Add(new ProductEntity()
            {
                Id = 3,
                Type = "Chicken",
                Name = "Chicken wing",
                Brand = "Imba",
                Price = 7,
                FoodId = 2 //FoodModel with "Meat" name
            });
            _products.Add(new ProductEntity()
            {
                Id = 4,
                Type = "Sausage",
                Name = "Sausage 8pack",
                Brand = "Stege",
                Price = 16,
                FoodId = 2 //FoodModel with "Meat" name
            });
        }

        //FOODS
        public IEnumerable<FoodEntity> GetFoods(string orderBy = "Id")
        {
            switch (orderBy.ToLower())
            {
                case "name":
                    return _foods.OrderBy(f => f.Name);
                default:
                    return _foods.OrderBy(f => f.Id);
            }
        }
        public FoodEntity GetFood(long foodId)
        {
            return _foods.FirstOrDefault(f => f.Id == foodId);
        }
        public FoodEntity UpdateFood(long foodId, FoodEntity updatedFood)
        {
            throw new NotImplementedException();
        }
        public FoodEntity CreateFood(FoodEntity newFood)
        {
            var next_Id = _foods.OrderByDescending(f => f.Id).FirstOrDefault().Id + 1;
            newFood.Id = next_Id;
            _foods.Add(newFood);
            return newFood;
        }
        public bool DeleteFood(long foodId)
        {
            throw new NotImplementedException();
        }

        //PRODUCTS
        public ProductEntity CreateProduct(long foodId, ProductEntity newCandy)
        {
            throw new NotImplementedException();
        }


        public bool DeleteProduct(long foodId, long candyId)
        {
            throw new NotImplementedException();
        }


        public ProductEntity GetProduct(long foodId, long candyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetProducts(long foodId)
        {
            throw new NotImplementedException();
        }


        public ProductEntity UpdateProduct(long foodId, long candyId, ProductEntity updatedCandy)
        {
            throw new NotImplementedException();
        }
    }
}
