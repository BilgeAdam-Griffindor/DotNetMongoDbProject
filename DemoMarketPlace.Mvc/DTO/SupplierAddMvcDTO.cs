using DemoMarketPlace.WebApi.Model;

namespace DemoMarketPlace.Mvc.DTO
{
    public class SupplierAddMvcDTO
    {
        public string CompanyName { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public List<AddressListDTO> Sehir { get; set; }
        public List<AddressListDTO> Ilce { get; set; }
    }
}
