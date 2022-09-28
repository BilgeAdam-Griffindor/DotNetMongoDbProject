using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Mongo;
using DemoMarketPlace.WebApi.MongoModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DemoMarketPlace.WebApi.DAL.Concrete
{
    public class MongoLog : IMongoLog
    {
        IMongoCollection<Log> _MongoCollection;
        public MongoLog(IOptions<MongoSettings> MongoSettings)
        {
            var mongoSettings = MongoClientSettings.FromConnectionString(MongoSettings.Value.ConnectionString);
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);


            var client = new MongoClient(mongoSettings);

            var database = client.GetDatabase(MongoSettings.Value.DatabaseName);

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
    }
}
