using DemoMarketPlace.WebApi.Dto;

namespace DemoMarketPlace.WebApi.DAL.Interface
{
    public interface ICategoryDAL
    {
        Task<List<CategoryListDTO>> GetAll();
        Task<bool> AddNewCategory(CategoryAddDTO addDTO);
    }
}
