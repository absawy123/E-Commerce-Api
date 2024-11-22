using Domain.Entities;

namespace Domain.Repos
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        Task<IEnumerable<Product>> GetTopExpensive(int count);

    }
}
