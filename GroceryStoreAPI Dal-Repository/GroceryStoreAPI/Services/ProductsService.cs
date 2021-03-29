using AutoMapper;
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
        //Automapper
        private IMapper _mapper;

        public ProductsService(IFoodsService foodsService, IMapper mapper)
        {
            _foodsService = foodsService;
            _mapper = mapper;
        }
        public IEnumerable<ProductModel> GetProducts(long foodId)
        {
            ValidateFood(foodId);
            return _products.Where(p => p.FoodId == foodId);
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

        //Bussines logic endpoint methods logic
    }
}
