using DataAccess.Data;
using Domain.Entities;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class ProductRepo : GenericRepo<Product> , IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetTopExpensive(int count) =>
        await _context.Products.AsNoTracking().Where(p => !p.IsDeleted).OrderByDescending(p => p.Price).Take(count).ToListAsync();
    }
        
   
}
