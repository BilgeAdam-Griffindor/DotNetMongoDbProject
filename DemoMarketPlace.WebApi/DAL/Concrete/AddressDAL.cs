using DemoMarketPlace.WebApi.Context;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.EntityFrameworkCore;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class AddressDAL:IAddressDAL
    {
        DemoDbContext _baseContext;
        IMongoLog _mongoLog;

        public AddressDAL(DemoDbContext baseContext, IMongoLog mongoLog)
        {
            _baseContext = baseContext;
            _mongoLog = mongoLog;
        }

        public async Task<List<AddressListDTO>> GetAllAddresses()
        {
           var DbResult= _baseContext.Addresses.ToList();
            List<AddressListDTO> addresses = new List<AddressListDTO>();
            foreach (var address in DbResult)
            {
                AddressListDTO adres = new AddressListDTO();
                adres.Id = address.AddressId;
                adres.AddressName = address.AddressName;
                adres.AddressType = address.AddressType;
                adres.TopAddressId = address.TopAddressId;
                addresses.Add(adres);
            }
            await _mongoLog.InsertAllAddressToMongo(addresses);
            return addresses;
        }

        public async Task<List<AddressListDTO>> GetAllAddressesFromMongo()
        {
            var result= await _mongoLog.GetAllAddressesFromMongo();
            List<AddressListDTO> ListOfaddresses = new List<AddressListDTO>();
            foreach (var item in result)
            {
                AddressListDTO addresses = new AddressListDTO();
                addresses.AddressName = item.AddressName;
                addresses.AddressType = item.AddressType;
                addresses.TopAddressId = item.TopAddressId;
                addresses.Id = item.AddressId;
                ListOfaddresses.Add(addresses);

            }

            return ListOfaddresses;
        }



    }
}
