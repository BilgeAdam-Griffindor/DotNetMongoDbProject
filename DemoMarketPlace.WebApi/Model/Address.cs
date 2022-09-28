namespace DemoMarketPlace.WebApi.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int? TopAddressId { get; set; }
        public Address TopAddress { get; set; }
        public int AddressType { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}
