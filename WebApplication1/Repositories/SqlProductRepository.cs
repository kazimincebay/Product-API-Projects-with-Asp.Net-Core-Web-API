using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly modelContext context;
        
        public SqlProductRepository(modelContext context)
        {
            this.context = context;

        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<bool> Exists(int productId)
        {
            return await context.Products.AnyAsync(x => x.productId == productId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await context.Products.FirstOrDefaultAsync(x=>x.productId == productId);
        }

        public async Task<Product> AddProduct(Product product)
        {
            var addproduct = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return addproduct.Entity;
        }





        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            var existProduct = await GetProductByIdAsync(productId);

            if (existProduct != null) {
            existProduct.productName=product.productName;
            existProduct.productPrice=product.productPrice;
            await context.SaveChangesAsync();
            return existProduct;
            }
            return null;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var existProduct = await GetProductByIdAsync(productId);

            if (existProduct != null)
            {
                context.Products.Remove(existProduct);
                
                await context.SaveChangesAsync();
                return existProduct;
            }
            return null;
        }
    }
}
