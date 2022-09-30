using DemoMarketPlace.WebApi.Context;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.EntityFrameworkCore;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class CategoryDAL : ICategoryDAL
    {
        DemoDbContext _baseContext;
        IMongoLog _mongoLog;

        public CategoryDAL(DemoDbContext baseContext, IMongoLog mongoLog)
        {
            _baseContext = baseContext;
            _mongoLog = mongoLog;
        }

        public async Task<bool> AddNewCategory(CategoryAddDTO addDTO)
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Category",
                LogLevel = "Info",
                OperationType = "Insert",
                CreatedDate = DateTime.Now
            };

            try
            {
                Category category = new Category();
                category.CategoryName = addDTO.CategoryName;
                category.Description = addDTO.Description;
                await _baseContext.Categories.AddAsync(category);
                _baseContext.SaveChanges();

                log.AffectedId = category.CategoryID;
                _mongoLog.AddLog(log);

                return true;
            }
            catch (Exception ex)
            {
                log.LogLevel = "Error";
                log.LogDetail = ex.Message;
                _mongoLog.AddLog(log);
            }

            return false;
        }

        public async Task<List<CategoryListDTO>> GetAll()
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Category",
                LogLevel = "Info",
                OperationType = "GetAll",
                CreatedDate = DateTime.Now
            };

            try
            {
                //var data = await _baseContext.Categories.Select(x => new CategoryListDTO()
                //{
                //    CategoryID = x.CategoryID,
                //    CategoryName = x.CategoryName
                //}).ToListAsync();
                var data = await _baseContext.Categories.Select(x => new CategoryListDTO(x.CategoryID, x.CategoryName)).ToListAsync();

                _mongoLog.AddLog(log);

                return data;
            }
            catch (Exception ex)
            {
                log.LogLevel = "Error";
                log.LogDetail = ex.Message;

                _mongoLog.AddLog(log);
            }

            return null;
        }
    }
}
