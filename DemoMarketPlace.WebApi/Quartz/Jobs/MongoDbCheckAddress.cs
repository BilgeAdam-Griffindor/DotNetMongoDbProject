using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;
using DemoMarketPlace.WebApi.Helper;
using Quartz;

namespace DemoMarketPlace.WebApi.Quartz.Jobs
{
    public class MongoDbCheckAddress:IJob
    {
        
        public readonly IAddressDAL _addressDAL;
        public MongoDbCheckAddress(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }

        public Task Execute(IJobExecutionContext context)
        {
            //GetAllAddresses
            //var data = _addressDAL.GetAllAddresses().Result;

            _addressDAL.GetAllAddresses();
            //Console.WriteLine("Selam kızlar");
            return Task.CompletedTask;
        }

    }
}
