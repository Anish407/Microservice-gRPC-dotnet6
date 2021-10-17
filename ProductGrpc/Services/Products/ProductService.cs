
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ProductGrpc.common.Exceptions;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos.Product;

namespace ProductGrpc.Services.Products;
public class ProductService : ProductProtoService.ProductProtoServiceBase
{
    public ProductService(List<Product> products)
    {
        Products = products;
    }

    public ProductContext ProductContext { get; }
    public List<Product> Products { get; }

    public override async Task<ProductModel> GetProduct(GetProductRequest request, ServerCallContext context)
    {
        var product = Products.FirstOrDefault(i => i.Id == request.ProductId);

        _ = product ?? throw new NotFoundException($"Product: {request.ProductId} not found");

        var productModel = new ProductModel
        {
            ProductId = product.Id,
            CreatedTime = Timestamp.FromDateTime(product.CreatedTime),
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            Status = (Protos.Product.ProductStatus)product.Status,
        };

        return productModel;
    }




}
