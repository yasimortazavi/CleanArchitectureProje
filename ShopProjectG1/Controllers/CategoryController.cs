using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Devsharp.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mapster;
using System.Threading.Tasks;
using Devsharp.Services.DTOs;
using Devsharp.Services.Extensions;
using Devsharp.Services.Catalog;
namespace ShopProjectG1.Controllers
{
 
    public class CategoryController : DevsharpController
    {
        #region Fields
        private readonly ICategoryService _categoryService = null;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.SearchCategoryAsync());
        }


        [HttpGet("Find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> FindAsync(int id)
        {

            var categoryDTO = await _categoryService.SearchCategoriyByIdAsync(id);
            if (categoryDTO == null)
            {
                return NotFound();
            }

            return Ok(categoryDTO);
        
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async  Task<IActionResult> RegisterAsync([FromForm] CategoryDTO model)
        {
            if (model.ID != 0)
                return BadRequest();

            await _categoryService.RegisterCategoryAsync(model);
            return CreatedAtAction("find", new { id = model.ID } , model);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromForm] CategoryDTO model)
        {
            if (await _categoryService.CheckExists(model.ID))
                return NotFound();

            await _categoryService.UpdateCategoryAsync(model);

            return NoContent();
        
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveAsync(int id)
        {

            var categoryDTO = await _categoryService.SearchCategoriyByIdAsync(id);
            if (categoryDTO == null)
                NotFound();

            await _categoryService.RemoveCategoryAsync(categoryDTO);

            return Ok();

        }
    }
}
