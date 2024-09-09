using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Devsharp.Framwork.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ShopProjectG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                .Select(p => new {
                    p.Name,
                    p.CreateOn,
                    p.ParentId,
                    parentName = p.ParentCategory.Name,
                    p.ID
                    ,
                    p.UpdateOn,
                    childCount = p.Children.Count,
                    productCount = p.ProductCategories.Count,
                    LocalCreateOn = p.CreateOn.ToPersian(),
                    LocalUpdateOn = p.UpdateOn.ToPersian(),
                });
            return Ok(_list);
        }
    }
}
