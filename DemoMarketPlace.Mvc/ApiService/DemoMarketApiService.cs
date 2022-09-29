using DemoMarketPlace.Mvc.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

                return JsonConvert.DeserializeObject<List<ProductListDTO>>(content);
            }

            return null;
        }

        public async Task<bool> AddNewProduct(ProductAddDTO addNew)
        {
            var body = new StringContent(JsonConvert.SerializeObject(addNew));
            body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("Product/Add-Product", body);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                bool.TryParse(content, out bool result);
                return result;
            }

            return false;
        }

        public async Task<SupplierCategoryListDTO> GetSupplierCategoryLists()
        {
            var response = await client.GetAsync("Product/GetSupplierCategoryList");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SupplierCategoryListDTO>(content);
            }

            return null;
        }
    }
}
