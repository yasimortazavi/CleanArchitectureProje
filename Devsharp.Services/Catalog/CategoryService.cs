using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devsharp.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Devsharp.Services.Extensions;

namespace Devsharp.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly IRepository<Category> _repositoryCategory = null;
        #endregion
        public CategoryService(IRepository<Category> repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public async Task<IEnumerable<CategoryDTO>> SearchCategoryAsync()
        {
            var _list = await _repositoryCategory.TableNoTracking
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
             }).ToListAsync();
            return _list;
        }
        public async Task<CategoryDTO> SearchCategoriyByIdAsync(int id)
        {
            var category = await _repositoryCategory.GetByIdAsync(id);
            return category.ToDTO<CategoryDTO>();
        }

        public async Task<CategoryDTO> RegisterCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = categoryDTO.ToEntity<Category>();
            await _repositoryCategory.InsertAsync(category);

            categoryDTO.ID = category.ID;
            return categoryDTO;

        }

        public async Task<bool> CheckExists(int id)
        {
            return (await _repositoryCategory.GetByIdAsNoTrackingAsync(id) != null);
        }
        public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = categoryDTO.ToEntity<Category>();
            await _repositoryCategory.UpdateAsync(category);

        }

        public async Task RemoveCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = categoryDTO.ToEntity<Category>();
            await _repositoryCategory.DeleteAsync(category);

        }
    }
}
