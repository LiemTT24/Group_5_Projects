using AutoMapper;
using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Group5_API_Project.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Group5_API_Project.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        public ProductControllers(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productServices.AllProducts();
            if (products is null)
            {
                return NotFound("The Product List is empty...");
            }
            var p = _mapper.Map<List<Product>, List<ProductResponseDTO>>(products);
            return Ok(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            var product = await _productServices.SingleProduct(id);
            if (product is null)
            {
                return NotFound("The Product does not existed!");
            }
            var p = _mapper.Map<Product, ProductResponseDTO>(product);
            return Ok(p);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchProductByName(string name)
        {
            try
            {
                var result = await _productServices.SearchProducts(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("duplicate/{name}")]
        public async Task<IActionResult> DuplicateChecked(string name)
        {
            bool checkDuplicate = await _productServices.CheckProductName(name);
            return Ok(!checkDuplicate);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Product product)
        {
            bool checkExist = await _productServices.AnyAsync(product.ProductID);
            if (checkExist)
            {
                return BadRequest("Oops!!!, Product is alredy existed.");
            }
            await _productServices.CreateAsync(product);
            return Ok("Created!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            bool check = await _productServices.AnyAsync(product.ProductID);
            if (!check)
            {
                return NotFound("The ProductID does not exist.");
            }
            await _productServices.UpdateAsync(product);
            return Ok("Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool check = await _productServices.AnyAsync(id);
            if (!check)
            {
                return NotFound("The ProductID does not exist.");
            }
            var c = await _productServices.GetAsync(id);
            await _productServices.DeleteAsync(c);
            return Ok("Deleted!");
        }
    }
}
