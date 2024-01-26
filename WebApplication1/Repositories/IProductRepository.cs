using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<bool> Exists(int productId);
        Task<Product> UpdateProduct(int productId,Product product);
        Task<Product> AddProduct(Product product);
        Task<Product> DeleteProductAsync(int productId);
    }
}
