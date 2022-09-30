using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Mongo;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class MongoLog : IMongoLog
    {
        IMongoCollection<Log> _MongoCollection;
        IMongoCollection<Addresses> _MongoAddressCollection;
        public MongoLog(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);


            var client = new MongoClient(mongoSettings);

            var database = client.GetDatabase(MongoSettings.Value.DatabaseName);
            _MongoAddressCollection = database.GetCollection<Addresses>(MongoSettings.Value.CollectionNameAddress);
            _MongoCollection = database.GetCollection<Log>(MongoSettings.Value.CollectionName);
        }
        public bool AddLog(Log log)
        {
            try
            {
                _MongoCollection.InsertOne(log);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public Log GetById(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> InsertAllAddressToMongo(List<AddressListDTO> address)
        {
            try
            {
                FilterDefinition<Addresses> getAll = Builders<Addresses>.Filter.Empty;
                await _MongoAddressCollection.DeleteManyAsync(getAll);
                List<Addresses> mongoAddress = new List<Addresses>();
                foreach (var item in address)
                {
                    Addresses addresses = new Addresses();
                    addresses.AddressId = item.Id;
                    addresses.AddressName = item.AddressName;
                    addresses.TopAddressId = item.TopAddressId;
                    addresses.AddressType = item.AddressType;
                    mongoAddress.Add(addresses);

                }
                await _MongoAddressCollection.InsertManyAsync(mongoAddress);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
         
        }

        public async Task<List<Addresses>> GetAllAddressesFromMongo()
        {
            return await _MongoAddressCollection.Find(_ => true).ToListAsync();
        }
    }
}
