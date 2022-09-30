namespace DemoMarketPlace.WebApi.Dto
{
    public record ProductAddDTO(string ProductName, int? SupplierID, int? CategoryID, string QuantityPerUnit, decimal? UnitPrice, short? UnitsInStock, short? UnitsOnOrder, short? ReorderLevel, bool Discontinued);
    //public class ProductAddDTO
    //{
    //    public string ProductName { get; set; }

    //    public int? SupplierID { get; set; }

    //    public int? CategoryID { get; set; }
    //    public string QuantityPerUnit { get; set; }
    //    public decimal? UnitPrice { get; set; }

    //    public short? UnitsInStock { get; set; }

    //    public short? UnitsOnOrder { get; set; }

    //    public short? ReorderLevel { get; set; }

    //    public bool Discontinued { get; set; }
    //}
}
