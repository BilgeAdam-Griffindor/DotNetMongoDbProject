using DemoMarketPlace.WebApi.Dto;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface ISupplierDAL
    {
        Task<List<SupplierListDTO>> GetAll();
        Task<bool> AddNewSupplier(SupplierAddApiDto addDTO);
    }
}
