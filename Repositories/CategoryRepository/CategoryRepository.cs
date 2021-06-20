using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Entities;
using backend.Interface;
using backend.Models.Category;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CategoryRepository(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<CategoryDto> CreateCate(CategoryDto model)
        {
            var category = new Category
            {
                CategoryName = model.CategoryName
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            var categories = new CategoryDto
            {
                CategoryName = category.CategoryName,
                CategoryId = category.CategoryId
            };
            return categories;
        }

        public async Task<CategoryDto> DeleteCate(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
            {
                throw new System.Exception("Not found");
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            var categories = new CategoryDto
            {
                CategoryName = category.CategoryName,
                CategoryId = category.CategoryId
            };
            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCate()
        {
            return await _dbContext.Categories.Select(category => new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CreateDate = category.CreateDate
            }).ToListAsync();
        }

        public async Task<CategoryDto> GetCateById(int id)
        {
            var categories = await _dbContext.Categories.FindAsync(id);
            if (categories == null)
            {
                throw new System.Exception("Not found");
            }
            var category = new CategoryDto
            {
                CategoryId = categories.CategoryId,
                CategoryName = categories.CategoryName
            };

            return category;
        }

        public async Task<CategoryDto> UpdateCate(int id, CategoryDto model)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
            {
                throw new System.Exception("Not found");
            }

            category.CategoryName = model.CategoryName;

            await _dbContext.SaveChangesAsync();
            var categories = new CategoryDto
            {
                CategoryName = category.CategoryName,
                CategoryId = category.CategoryId
            };
            return categories;
        }
    }
}