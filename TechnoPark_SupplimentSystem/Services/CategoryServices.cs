using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class CategoryServices
    {
        private EFDBContext _dbContext;

        public CategoryServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateCategory(CategoryModel model)
        {
            try
            {
                if (CheckCategoryDuplicate(model.CategoryName))
                {
                    CategoryEntities entities = new CategoryEntities();
                    entities.CategoryName = model.CategoryName;
                    await _dbContext.Category.AddAsync(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckCategoryDuplicate(string categoryName)
        {
            try
            {
                var dataResult = _dbContext.Category.Where(x => x.CategoryName == categoryName).FirstOrDefault();
                if (dataResult != null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateCategory(CategoryModel model)
        {
            try
            {
                CategoryEntities entities = new CategoryEntities();
                if (CheckCategoryDuplicate(model.CategoryName))
                {
                    entities = await _dbContext.Category.AsNoTracking().Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    entities.CategoryName = model.CategoryName;
                    _dbContext.Category.Update(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryModel>> CategoryList()
        {
            return await _dbContext.Category.Select(x => new CategoryModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).ToListAsync();
        }

        public async Task<int> DeleteCategory(int Id)
        {
            try
            {
                CategoryEntities entities = new CategoryEntities();
                entities = await _dbContext.Category.Where(x => x.Id == Id).FirstOrDefaultAsync();
                _dbContext.Category.Remove(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
