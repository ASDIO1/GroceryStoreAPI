using GroceryStoreAPI.Exceptions;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/foods/{foodId:long}/[Controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productService;
        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> GetProducts(long foodId, double budget = 0, double discount = 0)//Gets product equals or under the users budget
        {
            try
            {
                var products = _productService.GetProducts(foodId, budget, discount);
                return Ok(products);
            }
            catch (NotFoundItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        [HttpGet("{productId:long}")]
        public IActionResult GetProduct(long foodId, long productId) //ActionResult<ProductModel>
        {
            try
            {
                var product = _productService.GetProduct(foodId, productId);
                return Ok(product);
            }
            catch (NotFoundItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        [HttpPost()]
        public IActionResult CreateProduct(long foodId,[FromBody] ProductModel newProduct) //ActionResult<ProductModel>
        {
            try
            {
                if (!ModelState.IsValid)//Validates if Model restrictions are fullfiled
                {
                    return BadRequest(ModelState);
                }
                var createdProduct = _productService.CreateProduct(foodId, newProduct);
                return Created($"api/foods/{foodId}/{createdProduct.Id}", createdProduct);
            }
            catch (NotFoundItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        [HttpDelete("{productId:long}")]
        public IActionResult DeleteProduct(long foodId, long productId)//ActionResult<bool>
        {
            try
            {
                var result = _productService.DeleteProduct(foodId, productId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        [HttpPut("{productId:long}")]
        public IActionResult UpdateProduct(long foodId, long productId,[FromBody] ProductModel productToUpdate)
        {
            try
            {
                var updatedProduct = _productService.UpdateProduct(foodId, productId, productToUpdate);
                return Ok(updatedProduct);
            }
            catch (NotFoundItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        // Bussines logic endpoints:
        // 1 BudgetProducts  Applied over the "GetProducts" Endpoint.  Gets product equals or under the users budget
    }
}
