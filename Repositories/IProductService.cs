using GraphQlWebApi.Entities;

namespace GraphQlWebApi.Repositories;
public interface IProductService
{
    public Task<List<Product>> ProductListAsync();

    public Task<Product> GetProductDetailByIdAsync(Guid productId);

    public Task<bool> AddProductAsync(Product productDetails);

    public Task<bool> UpdateProductAsync(Product productDetails);

    public Task<bool> DeleteProductAsync(Guid productId);
}