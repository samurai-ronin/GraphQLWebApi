using GraphQlWebApi.Entities;
using GraphQlWebApi.Repositories;

namespace GraphQlWebApi.Types;
public class ProductQueryTypes
{
    public async Task<List<Product>> GetProductListAsync([Service] IProductService productService)
    {
        return await productService.ProductListAsync();
    }

    public async Task<Product> GetProductDetailsByIdAsync([Service] IProductService productService, Guid productId)
    {
        return await productService.GetProductDetailByIdAsync(productId);
    }
}