using DemoMarketPlace.WebApi.Context;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.EntityFrameworkCore;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class ProductDAL : IProductDAL
    {
        DemoDbContext _baseContext;
        IMongoLog _mongoLog;

        public ProductDAL(DemoDbContext baseContext, IMongoLog mongoLog)
        {
            _baseContext = baseContext;
            _mongoLog = mongoLog;
        }

        public async Task<bool> AddNewProduct(ProductAddDTO addDTO)
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Product",
                LogLevel = "Info",
                OperationType = "Insert",
                CreatedDate = DateTime.Now
            };

            try
            {
                Product product = new Product()
                {
                    ProductName = addDTO.ProductName,
                    SupplierID = addDTO.SupplierID,
                    CategoryID = addDTO.CategoryID,
                    QuantityPerUnit = addDTO.QuantityPerUnit,
                    UnitPrice = addDTO.UnitPrice,
                    UnitsInStock = addDTO.UnitsInStock,
                    UnitsOnOrder = addDTO.UnitsOnOrder,
                    ReorderLevel = addDTO.ReorderLevel,
                    Discontinued = addDTO.Discontinued
                };
                await _baseContext.Products.AddAsync(product);
                _baseContext.SaveChanges();

                log.AffectedId = product.ProductID;
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

        public async Task<List<ProductListDTO>> GetAll()
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Product",
                LogLevel = "Info",
                OperationType = "GetAll",
                CreatedDate = DateTime.Now
            };

            try
            {
                var data = await _baseContext.Products.Select(x => new ProductListDTO()
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                }).ToListAsync();

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

        public async Task<SupplierCategoryListDTO> GetSupplierCategoryList()
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Product",
                LogLevel = "Info",
                OperationType = "GetAll",
                CreatedDate = DateTime.Now
            };

            try
            {
                SupplierCategoryListDTO supplierCategoryListDTO = new SupplierCategoryListDTO();
                supplierCategoryListDTO.CategoryList = await _baseContext.Categories.Select(x => new CategoryListDTO()
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName
                }).ToListAsync();

                supplierCategoryListDTO.SupplierList = await _baseContext.Suppliers.Select(x => new SupplierListDTO()
                {
                    SupplierID = x.SupplierID,
                    CompanyName = x.CompanyName
                }).ToListAsync();

                _mongoLog.AddLog(log);

                return supplierCategoryListDTO;
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
