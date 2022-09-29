using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.MongoModel;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface IMongoLog
    {
        Log GetById(string id);
        bool AddLog(Log log);

        Task<bool> InsertAllAddressToMongo(List<AddressListDTO> address);

        Task<List<Addresses>> GetAllAddressesFromMongo();
    }
}
