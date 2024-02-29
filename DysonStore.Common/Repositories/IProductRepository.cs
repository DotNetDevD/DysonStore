using DysonStore.Common.Models;

namespace DysonStore.Common.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(int genreId = 0);
        Task<IEnumerable<Category>> Categories();
        Task<Product> GetProductAsync(int productId);
    }
}