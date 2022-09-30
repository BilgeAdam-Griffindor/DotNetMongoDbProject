using DemoMarketPlace.WebApi.Dto;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface IAddressDAL
    {
        Task<List<AddressListDTO>> GetAllAddresses();
        Task<List<AddressListDTO>> GetAllAddressesFromMongo();
    }
}
