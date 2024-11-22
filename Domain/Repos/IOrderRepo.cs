using Domain.Entities;

namespace Domain.Repos
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    }
}
