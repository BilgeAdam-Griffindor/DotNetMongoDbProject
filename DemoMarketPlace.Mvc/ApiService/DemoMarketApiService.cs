using DemoMarketPlace.Mvc.DTO;
using MongoDB.Bson.IO;

namespace DemoMarketPlace.Mvc.ApiService
{
    public class DemoMarketApiService
    {
        HttpClient client;

        public DemoMarketApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<ProductListDTO>> GetAllProducts()
        {
            var response = await client.GetAsync("Product/Get-Product");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductListDTO>>(content);
            }

            return null;
        }
    }
}
