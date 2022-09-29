using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryDAL _categoryDAL;

        public CategoryController(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        [HttpGet("Get-Category")]
        public async Task<IActionResult> Index()
        {
            List<CategoryListDTO> data = await _categoryDAL.GetAll();
            //var data = await _baseContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(data);
        }
        [HttpPost("Add-Category")]
        public async Task<IActionResult> AddCategory(CategoryAddDTO category)
        {
            try
            {
                await _categoryDAL.AddNewCategory(category);

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
