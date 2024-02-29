using DysonStore.Common.Repositories;

namespace DysonStore.Common.Extensions
{
    public static class AddRepositoryDependeciesExtensions
    {
        public static void AddRepositoryDependecies(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IUserOrderRepository, UserOrderRepository>();
        }
    }
}
