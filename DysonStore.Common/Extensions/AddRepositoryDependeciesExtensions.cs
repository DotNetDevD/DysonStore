using DysonStore.Common.Repositories;

namespace DysonStore.Common.Extensions
{
    public static class AddRepositoryDependeciesExtensions
    {
        public static void AddRepositoryDependecies(this IServiceCollection services)
        {
            services.AddTransient<IHomeRepository, HomeRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IUserOrderRepository, UserOrderRepository>();
        }
    }
}
