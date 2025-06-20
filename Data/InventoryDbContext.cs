using InventoryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryProject.Data;

public class InventoryDbContext: DbContext
{   
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }
    public DbSet<InventoryModel> InventoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InventoryModel>()
            .HasData(
                new InventoryModel
                {
                    Id = 1, 
                    Name = "Asus M10 Laptop", 
                    Category = Category.Electronics, 
                    Price = 70000, 
                    Quantity = 10
                },
                new InventoryModel
                {
                    Id = 2, 
                    Name = "Fabrilife T-Shirt", 
                    Category = Category.Clothing, 
                    Price = 800, 
                    Quantity = 50
                });
    }
}