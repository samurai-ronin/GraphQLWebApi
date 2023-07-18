using GraphQlWebApi.Entities;
using GraphQlWebApi.Repositories;

namespace GraphQlWebApi.Mutations;
public class ProductMutations
{
    public async Task<bool> AddProductAsync([Service] IProductService productService, Product productDetails)
    {
        return await productService.AddProductAsync(productDetails);
    }

    public async Task<bool> UpdateProductAsync([Service] IProductService productService, Product productDetails)
    {
        return await productService.UpdateProductAsync(productDetails);
    }

    public async Task<bool> DeleteProductAsync([Service] IProductService productService, Guid productId)
    {
        return await productService.DeleteProductAsync(productId);
    }
}