using DemoMarketPlace.WebApi.Context;
using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMarketPlace.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        BaseContext _baseContext;
        IMongoLog _mongoLog;
        public ProductController(BaseContext baseContext,IMongoLog mongoLog)
        {
            _baseContext = baseContext;
            _mongoLog = mongoLog;
        }
        [HttpGet("Get-Product")]
        public async Task<IActionResult> Index()
        {
            var data = await _baseContext.Suppliers.Include(x => x.Address).ToListAsync();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(data);
        }
        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct(SupplierDto supplier)
        {
            try
            {
                Supplier s = new Supplier();
                s.CompanyName = supplier.CompanyName;
                s.AddressId = supplier.AddressId;
                await _baseContext.Suppliers.AddAsync(s);
                _baseContext.SaveChanges();
                _mongoLog.AddLog(new Log()
                {
                    LogDetail = "Ekleme Yapıldı",
                    CreatedDate = DateTime.Now,
                    BaseUserId = 1
                });
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            
           // var data = await _baseContext.Suppliers.Include(x => x.Address).ToListAsync();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            //return Ok(data);
        }
    }
}
