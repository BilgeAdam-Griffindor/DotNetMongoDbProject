using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Model;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(data);
        }

        [HttpPost("Add-Supplier")]
        public async Task<IActionResult> AddSupplier(SupplierAddApiDto supplier)
        {
            try
            {
                await _supplierDAL.AddNewSupplier(supplier);

                return Ok(true);
            }
            catch (Exception)
            {
                //TODO Bu doğrumu
                return StatusCode(500);
            }
        }
    }
}
