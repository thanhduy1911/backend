using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models.Category;

namespace backend.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetCate();
        Task<CategoryDto> GetCateById(int id);
        Task<CategoryDto> CreateCate(CategoryDto model);
        Task<CategoryDto> DeleteCate(int id);
        Task<CategoryDto> UpdateCate(int id,CategoryDto model);
        
    }
}