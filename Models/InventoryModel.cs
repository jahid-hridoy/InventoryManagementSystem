namespace InventoryProject.Models;

public class InventoryModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required Category Category { get; set; }
    public required float Price { get; set; }
    public required int Quantity { get; set; }
}

public enum Category
{
    Electronics,
    Clothing,
    HomeGoods,
    Sports,
    Toys,
    Books,
    Food,
    HealthAndBeauty
}