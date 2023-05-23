using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;

using Quartz;
using System.Data;

namespace DemoMarketPlace.WebApi.Quartz.Jobs
{

    public class MongoDbCheckAddress : IJob
    {

        public readonly IServiceScopeFactory _scopeFactory;
        public MongoDbCheckAddress(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task Execute(IJobExecutionContext context)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IAddressDAL>();

                var list = service.GetAllAddresses().Result;
            }

            Console.WriteLine("deneme");
            //Bu task complete kesin gerekli yoksa derlenmiyor.
            return Task.CompletedTask;
        }

    }
}
