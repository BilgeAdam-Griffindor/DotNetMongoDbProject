using DemoMarketPlace.WebApi.DAL.Concrete;
using DemoMarketPlace.WebApi.DAL.Interface;

namespace DemoMarketPlace.WebApi.Helper
{
    public class QuartzMongoDbAddressHelper
    {
        static IAddressDAL _AddressDAL;
        public QuartzMongoDbAddressHelper( IAddressDAL AddressDAL)
        {
            _AddressDAL = AddressDAL;
            
        }
        public static void JobCreate()
        {
            _AddressDAL.GetAllAddresses();
        }

        
    }
}
