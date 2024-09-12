using Devsharp.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devsharp.Services.Catalog
{
    public interface ICategoryService
    {
        Task<bool> CheckExists(int id);
        Task<CategoryDTO> RegisterCategoryAsync(CategoryDTO categoryDTO);
        Task RemoveCategoryAsync(CategoryDTO categoryDTO);
        Task<CategoryDTO> SearchCategoriyByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> SearchCategoryAsync();
        Task UpdateCategoryAsync(CategoryDTO categoryDTO);
    }
}