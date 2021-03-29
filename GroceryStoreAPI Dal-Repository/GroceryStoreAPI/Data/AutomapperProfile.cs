using AutoMapper;
using GroceryStoreAPI.Data.Entities;
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<FoodModel, FoodEntity>()
                .ReverseMap();

            this.CreateMap<ProductModel, ProductEntity>()
                .ReverseMap();
        }
    }
}
