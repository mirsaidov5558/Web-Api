using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Service.CategoryService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var categories = await _categoryService.GetAll();
            return Ok("Category");
        }


        [HttpGet("children/{parentCategoryId}")]
        public async Task<IActionResult> GetChild(int parentCategoryId)
        {
            var childCategories = await _categoryService.GetChild(parentCategoryId);
            return Ok(childCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                return BadRequest("Название категории не может быть пустым.");

            var result = await _categoryService.Create(categoryDto.Name, categoryDto.ParentCategoryId);
            if (!result)
                return BadRequest("Ошибка при создании категории.");

            return Ok(new { Message = "Категория успешно создана." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                return BadRequest("Название категории не может быть пустым.");

            var result = await _categoryService.Update(id, categoryDto.Name, categoryDto.ParentCategoryId);
            if (!result)
                return NotFound("Категория не найдена.");

            return Ok(new { Message = "Категория успешно обновлена." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);
            if (!result)
                return NotFound("Категория не найдена.");

            return Ok(new { Message = "Категория успешно удалена." });
        }
    }
}
