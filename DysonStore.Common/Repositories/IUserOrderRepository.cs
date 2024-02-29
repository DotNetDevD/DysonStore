using DysonStore.Common.Models;

namespace DysonStore.Common.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}