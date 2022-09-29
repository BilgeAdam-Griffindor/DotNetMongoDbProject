using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMarketPlace.WebApi.Dto
{
    public class CategoryListDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
