using DemoMarketPlace.WebApi.Context;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class SupplierDAL : ISupplierDAL
    {
        DemoDbContext _baseContext;
        IMongoLog _mongoLog;

        public SupplierDAL(DemoDbContext baseContext, IMongoLog mongoLog)
        {
            _baseContext = baseContext;
            _mongoLog = mongoLog;
        }

        public async Task<bool> AddNewSupplier(SupplierAddDto addDTO)
        {
            Log log = new Log(){
                BaseUserId = 1,
                TableName = "Supplier",
                LogLevel = "Info",
                OperationType = "Insert",
                CreatedDate = DateTime.Now
            };

            try
            {
                Supplier s = new Supplier();
                s.CompanyName = addDTO.CompanyName;
                s.AddressId = addDTO.AddressId;
                await _baseContext.Suppliers.AddAsync(s);
                _baseContext.SaveChanges();

                log.AffectedId = s.SupplierID;
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

        public async Task<List<SupplierListDTO>> GetAll()
        {
            Log log = new Log()
            {
                BaseUserId = 1,
                TableName = "Supplier",
                LogLevel = "Info",
                OperationType = "GetAll",
                CreatedDate = DateTime.Now
            };

            try
            {
                var data = await _baseContext.Suppliers.Select(x => new SupplierListDTO()
                {
                    SupplierID = x.SupplierID,
                    CompanyName = x.CompanyName
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
    }
}
