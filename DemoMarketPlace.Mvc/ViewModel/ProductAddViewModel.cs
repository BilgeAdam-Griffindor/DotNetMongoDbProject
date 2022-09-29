using DemoMarketPlace.Mvc.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMarketPlace.Mvc.ViewModel
{
    public class ProductAddViewModel
    {
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }
}
