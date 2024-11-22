using DataAccess.Data;
using Domain.Entities;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class OrderRepo : GenericRepo<Order> , IOrderRepo
    {
       
       private readonly AppDbContext _context;
       public OrderRepo(AppDbContext context) : base(context)
       {
           _context = context;
       }

       public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status) =>
        await _context.Orders.AsNoTracking()
            .Where(o => EF.Functions.Collate(o.Status, "SQL_Latin1_General_CP1_CI_AS") == status).ToListAsync();
       
    }
}
