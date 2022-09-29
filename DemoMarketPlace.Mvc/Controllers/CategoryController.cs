using DemoMarketPlace.Mvc.ApiService;
using DemoMarketPlace.Mvc.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMarketPlace.Mvc.Controllers
{
    public class CategoryController:Controller
    {
        private readonly DemoMarketApiService demoMarketApiService;
        public CategoryController(DemoMarketApiService demoMarketApiService)
        {
            this.demoMarketApiService = demoMarketApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await demoMarketApiService.GetAllCategoryAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Save() 
        {
            CategoryAddDTO categoryAddDTO = new CategoryAddDTO();
            var categoriesDto = await demoMarketApiService.SaveCategoryAsync(categoryAddDTO);

            ViewBag.Categories = new SelectList("Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryAddDTO categoryAddDTO)
        {
            if (ModelState.IsValid)
            {
                await demoMarketApiService.SaveCategoryAsync(categoryAddDTO);
                return RedirectToAction("Index");
            }

            var categoriesDto = await demoMarketApiService.GetAllCategoryAsync();
            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }

    }
}
