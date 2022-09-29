using DemoMarketPlace.WebApi.MongoModel;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface IMongoLog
    {
        Log GetById(string id);
        bool AddLog(Log log);
    }
}
