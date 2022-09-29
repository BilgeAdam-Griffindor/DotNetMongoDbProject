using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        ISupplierDAL _supplierDAL;

        public SupplierController(ISupplierDAL supplierDAL)
        {
            _supplierDAL = supplierDAL;
        }

        [HttpGet("Get-Supplier")]
        public async Task<IActionResult> Index()
        {
            List<SupplierListDTO> data = await _supplierDAL.GetAll();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(data);
        }

        [HttpPost("Add-Supplier")]
        public async Task<IActionResult> AddSupplier(SupplierAddDto supplier)
        {
            try
            {
                await _supplierDAL.AddNewSupplier(supplier);

                return Ok();
            }
            catch (Exception)
            {
                //TODO Bu doğrumu
                return StatusCode(500);
            }

            // var data = await _baseContext.Suppliers.Include(x => x.Address).ToListAsync();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            //return Ok(data);
        }
    }
}
