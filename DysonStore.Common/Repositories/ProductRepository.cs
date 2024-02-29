using DysonStore.Common.Data;
using DysonStore.Common.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DysonStore.Common.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(int productId = 0)
        {
            IEnumerable<Product> products = await (from product in _db.Products
                                                   join category in _db.Categories
                                                   on product.CategoryId equals category.Id
                                                   select new Product
                                                   {
                                                       Id = product.Id,
                                                       Image = product.Image,
                                                       ProductName = product.ProductName,
                                                       CategoryId = product.CategoryId,
                                                       Discription = product.Discription,
                                                       Price = product.Price,
                                                       CategoryName = category.CategoryName
                                                   }
                         ).ToListAsync();

            return products;

        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var product = await GetProducts();

            return product.SingleOrDefault(i => i.Id == productId);
        }
    }
}
