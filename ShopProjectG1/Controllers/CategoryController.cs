using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Devsharp.Framework.Extensions;
using Devsharp.Framwork.DTOs;
using Devsharp.Framwork.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mapster;
using System.Threading.Tasks;
namespace ShopProjectG1.Controllers
{
 
    public class CategoryController : DevsharpController
    {
        #region Fields
        private readonly IRepository<Category> _repositoryCategory = null;
        #endregion

        public CategoryController(IRepository<Category> repositoryCategory)
        {
            this._repositoryCategory = repositoryCategory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _list = _repositoryCategory.TableNoTracking
                 .Select(p => new CategoryDTO
                 {
                     CreateOn = p.CreateOn,
                     ID = p.ID,
                     Name = p.Name,
                     ParentId = p.ParentId,
                     ParentName = p.ParentCategory.Name,
                     UpdateOn = p.UpdateOn,
                     ChildCount = p.Children.Count,
                     ProdcutCount = p.ProductCategories.Count,
                     LocalCreateOn = p.CreateOn.ToPersian(),
                     LocalUpdateOn = p.UpdateOn.ToPersian()
                 });
            return Ok(_list);
        }


        [HttpGet("Find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> FindAsync(int id)
        {
            //var result = _repositoryCategory.Table.Include(p => p.ProductCategories).SingleOrDefault(p => p.ID == id);
            var category = await _repositoryCategory.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDTO = category.ToDTO<CategoryDTO>();



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
            var category = model.ToEntity<Category>();
            await _repositoryCategory.InsertAsync(category);

            model.ID = category.ID;
            return CreatedAtAction("find", new { id = model.ID } , model);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync([FromForm] CategoryDTO model)
        {
            if (await _repositoryCategory.GetByIdAsNoTrackingAsync(model.ID) == null)
                return NotFound();


            var category = model.ToEntity<Category>();
            await _repositoryCategory.UpdateAsync(category);

            return NoContent();
        
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Remove(int id)
        {

            var category = _repositoryCategory.GetByIdAsync(ids: id);
            if (category == null)
                NotFound();

            _repositoryCategory.Delete(category);

            return Ok();

        }
    }
}
