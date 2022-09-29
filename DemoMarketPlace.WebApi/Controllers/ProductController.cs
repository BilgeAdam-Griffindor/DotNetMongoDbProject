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
        IProductDAL _productDAL;
        public ProductController(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        [HttpGet("Get-Product")]
        public async Task<IActionResult> Index()
        {
            var data = await _productDAL.GetAll();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(data);
        }
        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct(ProductAddDTO addDTO)
        {
            try
            {
                _productDAL.AddNewProduct(addDTO);
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
