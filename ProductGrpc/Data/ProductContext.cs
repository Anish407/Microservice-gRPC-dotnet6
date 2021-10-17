
using Microsoft.EntityFrameworkCore;
using ProductGrpc.Models;

namespace ProductGrpc.Data;

public class ProductContext : DbContext
{

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-FSA8LOOJ\SQLEXPRESS;Database=productgrpc;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Product>().HasData(new Product
        //{
        //    ProductId = 1,
        //    Name = "Mi10T",
        //    Description = "New Xiaomi Phone Mi10T",
        //    Price = 699,
        //    Status = ProductGrpc.Models.ProductStatus.INSTOCK,
        //    CreatedTime = DateTime.UtcNow
        //},
        //  new Product
        //  {
        //      ProductId = 2,
        //      Name = "P40",
        //      Description = "New Huawei Phone P40",
        //      Price = 899,
        //      Status = ProductGrpc.Models.ProductStatus.INSTOCK,
        //      CreatedTime = DateTime.UtcNow
        //  },
        //  new Product
        //  {
        //      ProductId = 3,
        //      Name = "A50",
        //      Description = "New Samsung Phone A50",
        //      Price = 399,
        //      Status = ProductGrpc.Models.ProductStatus.INSTOCK,
        //      CreatedTime = DateTime.UtcNow
        //  });
       // base.OnModelCreating(modelBuilder);
    }

}
