using GroceryStoreAPI.Exceptions;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class ProductsService : IProductsService
    {
        //Estados de prueba
        private ICollection<ProductModel> _products;
        //Service del otro recurso
        private IFoodsService _foodsService;
        public ProductsService(IFoodsService foodsService)
        {
            _foodsService = foodsService;

            _products = new List<ProductModel>();
            _products.Add(new ProductModel()
            {
                Id = 1,
                Type = "Chocolate",
                Name = "Sublime",
                Brand = "Nestle",
                Price = 2, 
                FoodId = 1 //FoodModel with "Candy" name
            });
            _products.Add(new ProductModel()
            {
                Id = 2,
                Type = "Gummies",
                Name = "Cerebritos",
                Brand = "Mogul",
                Price = 2.50,
                FoodId = 1 //FoodModel with "Candy" name
            });
            _products.Add(new ProductModel()
            {
                Id = 3,
                Type = "Chicken",
                Name = "Chicken wing",
                Brand = "Imba",
                Price = 7,
                FoodId = 2 //FoodModel with "Meat" name
            });
            _products.Add(new ProductModel()
            {
                Id = 4,
                Type = "Sausage",
                Name = "Sausage 8pack",
                Brand = "Stege",
                Price = 16,
                Discount = 0.2,//%
                FoodId = 2 //FoodModel with "Meat" name
            });
        }
        public IEnumerable<ProductModel> GetProducts(long foodId, double budget = 0, double discount = 0)
        {
            ValidateFood(foodId);
            var allProducts = _products.Where(p => p.FoodId == foodId);
            if (budget < 0)
                throw new InvalidOperationItemException($"The budget value: {budget} is invalid, enter a budget equals or greater than 0 please");
            if (discount < 0 || discount > 0.99)
                throw new InvalidOperationItemException($"The discount value: {discount} is invalid, enter a discount int he range of 0 to 0.99 please");

            allProducts = CheckGetQueryParams(allProducts, budget, discount);
            return allProducts;

        }
        public ProductModel GetProduct(long foodId, long productId)
        {
            ValidateFood(foodId);
            var product = _products.FirstOrDefault(p => p.FoodId == foodId && p.Id == productId);
            if (product == null)
                throw new NotFoundItemException($"The product with id: {productId} does not exist in the food with id: {foodId}.");
            return product;
        }

        public ProductModel CreateProduct(long foodId, ProductModel newProduct)
        {
            ValidateFood(foodId);
            newProduct.FoodId = foodId;//to avoid chainging the id
            var nextId = _products.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;//gets las Id and adds 1 to it
            newProduct.Id = nextId;
            _products.Add(newProduct);
            return newProduct;
        }

        public bool DeleteProduct(long foodId, long productId)
        {
            ValidateFood(foodId);
            var productToDelete = GetProduct(foodId, productId);
            _products.Remove(productToDelete);
            return true;
        }

        public ProductModel UpdateProduct(long foodId, long productId, ProductModel updatedProduct)
        {
            var productToUpdate = GetProduct(foodId, productId);
            productToUpdate.Type = updatedProduct.Type ?? productToUpdate.Type;
            productToUpdate.Name = updatedProduct.Name ?? productToUpdate.Name;
            productToUpdate.Brand = updatedProduct.Brand ?? productToUpdate.Brand;
            productToUpdate.Price = updatedProduct.Price ?? productToUpdate.Price;
            return productToUpdate;
        }

        //Aux Methods
        private void ValidateFood(long foodId) 
        {
            _foodsService.GetFood(foodId);//this already validates and throws exceptions
        }

        //BUSSINES LOGIC METHODS
        //When a person asks for a certain Food products under their budget
        private IEnumerable<ProductModel> GetBudgetProducts(double budget = 0)   //Gets all products <= budget, ordered from the cheapest
        {
            var requestedProducts = _products.Where(p => p.Price <= budget).OrderByDescending(p => p.Price);
            return requestedProducts;
        }
        //When a person asks for a certain Food products whit a certain discount
        private IEnumerable<ProductModel> GetDiscountProducts(double discount = 0)
        {
            var discountedProducts = _products.Where(p => p.Discount <= discount && p.Discount > 0).OrderByDescending(p => p.Discount);
            return discountedProducts;
        }

        private IEnumerable<ProductModel> CheckGetQueryParams(IEnumerable<ProductModel> allProducts, double budget = 0, double discount = 0)
        {
            if (budget > 0)
            {
                allProducts = GetBudgetProducts(budget);
            }
            if (discount >= 0 && discount <= 0.99)
            {
                allProducts = GetDiscountProducts(discount);
            }
            return allProducts;
        }
    }
}
