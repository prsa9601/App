using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Product.Create;
using Shop.Application.Product.Delete;
using Shop.Application.Product.Update;
using Shop.Presentation.Facade.Product;
using Shop.Query.Products.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiController
    {
        private readonly IProductFacade _facade;
        //private IConfiguration _configuration;
        //, IConfiguration configuration
        //_configuration = configuration;
        public ProductController(IProductFacade facade)
        {
            _facade = facade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParam filterParams)
        {
            return QueryResult(await _facade.GetProductsByFilter(filterParams));
        }

        //[AllowAnonymous]
        //[HttpGet("Shop")]
        //public async Task<ApiResult<ProductShopResult>> GetProductForShopFilter([FromQuery] ProductShopFilterParam filterParams)
        //{
        //    return QueryResult(await _productFacade.GetProductsForShop(filterParams));
        //}
        // GET: api/<ProductController>
        //[HttpGet]
        //public async Task<ApiResult<List<ProductDto?>>> GetList()
        //{
        //    var product = await _facade.GetProducts();
        //    return QueryResult(product);
        //}

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> Get(long productId)
        {
            var product = await _facade.GetProductById(productId);
            return QueryResult(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ApiResult> Post([FromForm]CreateProductCommand product)
        {
            var result = await _facade.CreateProduct(new CreateProductCommand(){
                Title=product.Title,
                Price=product.Price
            });
            return CommandResult(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("edit")]
        public async Task<ApiResult> Put([FromBody] UpdateProductCommand command)
        {
            var result = await _facade.EditProduct(command);
            return CommandResult(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public async Task<ApiResult> Delete(long productId)
        {
            var result = await _facade.DeleteProduct(productId);
            return CommandResult(result);
        }
    }
}
