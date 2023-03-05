using AutoMapper;
using Group5_API_Project.DTO;
using Group5_API_Project.Models;
using Group5_API_Project.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Group5_API_Project.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryControllers : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;

        public CategoryControllers(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryServices.GetAllAsync();
            if (category is null)
            {
                return NotFound("The Category List is empty...");
            }
            var c = _mapper.Map<List<Category>, List<CategoryDTO>>(category);
            return StatusCode(StatusCodes.Status200OK, c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCategory(int id)
        {
            var category = await _categoryServices.GetAsync(id);
            if (category is null)
            {
                return NotFound("The Category does not existed!");
            }
            var c = _mapper.Map<Category, CategoryDTO>(category);
            return StatusCode(StatusCodes.Status200OK, c);
        }

        [HttpGet("duplicate/{id}")]
        public async Task<IActionResult> DuplicateChecked(int id)
        {
            bool checkDuplicate = await _categoryServices.AnyAsync(id);
            return Ok(!checkDuplicate);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryDTO category)
        {
            bool checkExist = await _categoryServices.AnyAsync(category.CategoryID);
            if (checkExist)
            {
                return BadRequest("Oops!!!, Category is alredy existed.");
            }
            var categories = _mapper.Map<CategoryDTO, Category>(category);
            await _categoryServices.CreateAsync(categories);
            return StatusCode(StatusCodes.Status201Created, categories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDTO category)
        {
            bool check = await _categoryServices.AnyAsync(category.CategoryID);
            if (!check)
            {
                return NotFound("The CategoryID does not exist.");
            }
            var categories = _mapper.Map<CategoryDTO, Category>(category);
            await _categoryServices.UpdateAsync(categories);
            return StatusCode(StatusCodes.Status204NoContent, categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool check = await _categoryServices.AnyAsync(id);
            if (!check)
            {
                return NotFound("The CategoryID does not exist.");
            }
            var c = await _categoryServices.GetAsync(id);
            await _categoryServices.DeleteAsync(c);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }   
}
