namespace DemoMarketPlace.WebApi.Dto
{
    public class AddressListDTO
    {
        public int  Id { get; set; }
        public string AddressName { get; set; }
        public int? TopAddressId { get; set; }
        public int AddressType { get; set; }
    }
}
