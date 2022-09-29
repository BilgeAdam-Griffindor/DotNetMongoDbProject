using Quartz;

namespace DemoMarketPlace.WebApi.Quartz.Jobs
{
    public class MongoDbCheckAddress:IJob
    {
        public MongoDbCheckAddress()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            //Todo Yapılacak İş
            System.Console.WriteLine("Evet Quart çalıştı.....");
            return Task.CompletedTask;
        }
    }
}
