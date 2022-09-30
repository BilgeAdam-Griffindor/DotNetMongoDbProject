using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;
using DemoMarketPlace.WebApi.Mongo;
using DemoMarketPlace.WebApi.Quartz.Jobs;

namespace DemoMarketPlace.WebApi.ServiceExtension
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection serviceDescriptors,IConfiguration configuration)
        {
            serviceDescriptors.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            serviceDescriptors.AddSingleton<IMongoLog, MongoLog>();
            serviceDescriptors.AddScoped<ICategoryDAL, CategoryDAL>();
            serviceDescriptors.AddScoped<ISupplierDAL, SupplierDAL>();
            serviceDescriptors.AddScoped<IProductDAL, ProductDAL>();
            
          
        }
    }
}
