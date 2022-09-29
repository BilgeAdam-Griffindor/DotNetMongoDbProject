using DemoMarketPlace.Mvc.DTO;
using Newtonsoft.Json;
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
        public async Task<List<SupplierListMvcDTO>> GetAllSuppliers()
        {
            var response = await client.GetAsync("Supplier/Get-Supplier");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<SupplierListMvcDTO>>(content);
            }
            return null;
        }
        public async Task<bool> AddSupplier(SupplierAddMvcSendDTO supplierAddMvcSendDTO)
        {
            var data = new StringContent(JsonConvert.SerializeObject(supplierAddMvcSendDTO));
            data.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("Supplier/Add-Supplier", data);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }
            return false;
        }
    }
}
