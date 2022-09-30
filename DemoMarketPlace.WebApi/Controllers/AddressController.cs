using DemoMarketPlace.WebApi.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressDAL _addresesDal;
        public AddressController(IAddressDAL addresesDal)
        {
            _addresesDal = addresesDal;
        }

        [HttpGet("GetAllAddressesFromSqlToMongo")]
        public async Task<IActionResult> GetAllAddressesFromSqlToMongo()
        {
            var result = await _addresesDal.GetAllAddresses();
            return Ok(result);
        }
        [HttpGet("GetAddressesFromMongo")]
        public async Task<IActionResult> GetAddressesFromMongo()
        {
            var result = await _addresesDal.GetAllAddressesFromMongo();
            return Ok(result);
        }




    }
}
