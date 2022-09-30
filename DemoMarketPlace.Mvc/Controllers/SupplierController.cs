using DemoMarketPlace.Mvc.ApiService;
using DemoMarketPlace.Mvc.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DemoMarketPlace.Mvc.Controllers
{
    public class SupplierController : Controller
    {
        DemoMarketApiService _demoMarketApiService;
        public SupplierController(DemoMarketApiService demoMarketApiService)
        {
            _demoMarketApiService = demoMarketApiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Anasayfa()
        {
            var data = await _demoMarketApiService.GetAllSuppliers();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddSuppliers()
        {
            var result = await _demoMarketApiService.GetAllAddresses();
            SupplierAddMvcDTO supplierDto = new SupplierAddMvcDTO();
            supplierDto.Sehir = result.Where(x => x.AddressType == 100).ToList();
            supplierDto.Ilce = result.Where(x => x.AddressType == 200).ToList();
            return View(supplierDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddSuppliers(SupplierAddMvcDTO supplierAddDTO)
        {
            SupplierAddMvcSendDTO supplierAddMvcSendDTO = new SupplierAddMvcSendDTO();
            supplierAddMvcSendDTO.AddressId = supplierAddDTO.IlceId;
            supplierAddMvcSendDTO.CompanyName = supplierAddDTO.CompanyName;
            var data = _demoMarketApiService.AddSupplier(supplierAddMvcSendDTO);
            return RedirectToAction("Anasayfa");
        }
    }
}
