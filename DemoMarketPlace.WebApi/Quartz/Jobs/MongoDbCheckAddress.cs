using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Dto;

using Quartz;

namespace DemoMarketPlace.WebApi.Quartz.Jobs
{
    
    public class MongoDbCheckAddress:IJob
    {

        //public readonly IDeneme _addressDAL;
        //public MongoDbCheckAddress(IDeneme addressDAL)
        //{
        //    _addressDAL = addressDAL;
        //}
        public MongoDbCheckAddress()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
          
             //await _addressDAL.GetAllAddresses();
            Console.WriteLine("deneme");
            //Bu task complete kesin gerekli yoksa derlenmiyor.
            return Task.CompletedTask;
        }

    }
}
