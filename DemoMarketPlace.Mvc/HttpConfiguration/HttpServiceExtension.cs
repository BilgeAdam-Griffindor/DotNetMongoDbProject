namespace DemoMarketPlace.Mvc.HttpConfiguration
{
    public class HttpServiceExtension
    {
        private static IConfiguration _Configuration;
        public static void Configure(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        
    }
}
