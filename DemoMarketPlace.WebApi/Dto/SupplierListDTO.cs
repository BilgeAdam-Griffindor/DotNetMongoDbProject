using System.ComponentModel.DataAnnotations;

namespace DemoMarketPlace.WebApi.Dto
{
    public class SupplierListDTO
    {
        public int? SupplierID { get; set; }
        public string CompanyName { get; set; }
    }
}
