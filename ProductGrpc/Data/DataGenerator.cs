
using ProductGrpc.Models;

namespace ProductGrpc.Data;
public class DataGenerator
{


    public static void SeedData(ProductContext ProductContext)
    {
        var products = new List<Product>()
        {
            new Product
         {
             Id = 1,
             Name = "Mi10T",
             Description = "New Xiaomi Phone Mi10T",
             Price = 699,
             Status = ProductGrpc.Models.ProductStatus.INSTOCK,
             CreatedTime = DateTime.UtcNow
         },
         new Product
         {
             Id = 2,
             Name = "P40",
             Description = "New Huawei Phone P40",
             Price = 899,
             Status = ProductGrpc.Models.ProductStatus.INSTOCK,
             CreatedTime = DateTime.UtcNow
         },
         new Product
         {
             Id = 3,
             Name = "A50",
             Description = "New Samsung Phone A50",
             Price = 399,
             Status = ProductGrpc.Models.ProductStatus.INSTOCK,
             CreatedTime = DateTime.UtcNow
         }
        };

        ProductContext.Products.AddRange(products);
         ProductContext.SaveChanges();
    }
}
