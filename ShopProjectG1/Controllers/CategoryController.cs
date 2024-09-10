using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Devsharp.Framwork.DTOs;
using Devsharp.Framwork.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public IActionResult Find(int id)
        {
            var result = _repositoryCategory.Table.Include(p => p.ProductCategories).SingleOrDefault(p => p.ID == id);
            //var result = _repositoryCategory.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Name = result.Name;
            categoryDTO.ID = result.ID;
            categoryDTO.ParentName = result.ParentCategory.Name;
            categoryDTO.ChildCount = result.Children.Count;
            categoryDTO.ProdcutCount = result.ProductCategories.Count;  

            return Ok(categoryDTO);
        
        }
    }
}
