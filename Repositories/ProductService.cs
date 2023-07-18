using GraphQlWebApi.Data;
using GraphQlWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQlWebApi.Repositories;
    public class ProductService : IProductService
    {
        private readonly ProjectContext dbContextClass;

        public ProductService(ProjectContext dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task<List<Product>> ProductListAsync()
        {
            return await dbContextClass.Products.ToListAsync();
        }

        public async Task<Product> GetProductDetailByIdAsync(Guid productId)
        {
            return await dbContextClass.Products.Where(ele => ele.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddProductAsync(Product productDetails)
        {
            await dbContextClass.Products.AddAsync(productDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product productDetails)
        {
            var isProduct = ProductDetailsExists(productDetails.Id);
            if (isProduct)
            {
                dbContextClass.Products.Update(productDetails);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var findProductData = dbContextClass.Products.Where(_ => _.Id == productId).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.Products.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool ProductDetailsExists(Guid productId)
        {
            return dbContextClass.Products.Any(e => e.Id == productId);
        }
    }