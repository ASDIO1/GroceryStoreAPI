using AutoMapper;
using GroceryStoreAPI.Data.Entities;
using GroceryStoreAPI.Data.Repositories;
using GroceryStoreAPI.Exceptions;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Services
{
    public class FoodsService : IFoodsService
    {
        //ESTADOS del modelo
        //static private IList<FoodModel> _foods;//THIS WILL BE MOVED TO THE REPOSITORY

        //QueryParam orderBy allowed values
        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name"
        };
        //GroceryStore Repository instance
        private IGroceryStoreRepository _groceryStoreRepository;
        //Autommaper instance
        private IMapper _mapper;

        //Estados de prueba del modelo
        public FoodsService(IGroceryStoreRepository repository, IMapper mapper)
        {
            _groceryStoreRepository = repository;
            _mapper = mapper;
        }

        //Endpoints desde el service
        public IEnumerable<FoodModel> GetFoods(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The orderBy value: {orderBy} is invalid, please use one of {String.Join(',',_allowedOrderByValues.ToArray())}");
            var entityList = _groceryStoreRepository.GetFoods(orderBy.ToLower());
            var modelList = _mapper.Map<IEnumerable<FoodModel>>(entityList);//Entity --> to  Model
            return modelList;
        }
        
        public FoodWithProductModel GetFood(long foodId)
        {
            var food = _groceryStoreRepository.GetFood(foodId);
            if (food == null)
            {
                throw new NotFoundItemException($"The food with id: {foodId} does not exist.");
            }
            var foodWithProducts = new FoodWithProductModel(_mapper.Map<FoodModel>(food));
            //foodWithProducts.Products = //THIS IS BEEING FIXED with a repository to avoid Ciclic Dependency
            return foodWithProducts;
        }
        public FoodModel CreateFood(FoodModel newFood)
        {
            var createdFood = _groceryStoreRepository.CreateFood(_mapper.Map<FoodEntity>(newFood));
            return _mapper.Map<FoodModel>(createdFood);
        }

        public bool DeleteFood(long foodId)
        {
            var foodToDelete = GetFood(foodId);
            _foods.Remove(foodToDelete);
            return true;
        }

        public FoodModel UpdateFood(long foodId, FoodModel updatedFood)
        {
            updatedFood.Id = foodId;
            var food = GetFood(foodId);
            food.Name = updatedFood.Name ?? food.Name;
            food.description = updatedFood.description ?? food.description;
            return food;
        }
    }
}
