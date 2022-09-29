using DemoMarketPlace.Mvc.ApiService;
using DemoMarketPlace.Mvc.DTO;
using DemoMarketPlace.Mvc.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMarketPlace.Mvc.Controllers
{
    public class ProductController : Controller
    {
        DemoMarketApiService _demoMarketApi;

        public ProductController(DemoMarketApiService demoMarketApi)
        {
            _demoMarketApi = demoMarketApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList = await _demoMarketApi.GetAllProducts();

            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var lists = await _demoMarketApi.GetSupplierCategoryLists();

            ProductAddViewModel viewModel = new ProductAddViewModel();

            viewModel.SupplierList = lists.SupplierList.Select(x => new SelectListItem()
            {
                Text = x.CompanyName,
                Value = x.SupplierID.ToString()
            }).ToList();

            viewModel.CategoryList = lists.CategoryList.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddViewModel viewData)
        {
            ProductAddDTO addDTO = new ProductAddDTO()
            {
                ProductName = viewData.ProductName,
                SupplierID = viewData.SupplierID,
                CategoryID = viewData.CategoryID,
                QuantityPerUnit = viewData.QuantityPerUnit,
                UnitPrice = viewData.UnitPrice,
                UnitsInStock = viewData.UnitsInStock,
                UnitsOnOrder = viewData.UnitsOnOrder,
                ReorderLevel = viewData.ReorderLevel,
                Discontinued = viewData.Discontinued
            };

            await _demoMarketApi.AddNewProduct(addDTO);

            return RedirectToAction("Index");
        }

    }
}
