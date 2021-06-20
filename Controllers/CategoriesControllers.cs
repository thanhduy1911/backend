using System.Threading.Tasks;
using backend.Constants;
using backend.Interface;
using backend.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesControllers : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesControllers(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetCategories()
        {
            var category = await _categoryRepository.GetCate();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryRepository.GetCateById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCate([FromBody] CategoryDto model)
        {
            var category = await _categoryRepository.CreateCate(model);
            return Created(Endpoint.Category, category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCate([FromRoute] int id, [FromBody] CategoryDto model)
        {
            var category = await _categoryRepository.UpdateCate(id, model);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> DeleteCate([FromRoute] int id)
        {
            var category = await _categoryRepository.DeleteCate(id);
            return Ok(category);
        }
    }
}