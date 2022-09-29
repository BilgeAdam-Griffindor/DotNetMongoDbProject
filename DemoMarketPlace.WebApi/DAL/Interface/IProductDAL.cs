using DemoMarketPlace.WebApi.Dto;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface IProductDAL
    {
        Task<List<ProductListDTO>> GetAll();
        Task<bool> AddNewProduct(ProductAddDTO addDTO);
        Task<SupplierCategoryListDTO> GetSupplierCategoryList();
    }
}
