using DataAccess.Data;
using Domain.Repos;

namespace DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepo ProductRepo { get; private set ;}
        public ICategoryRepo CategoryRepo { get; private set ; }
        public IOrderRepo OrderRepo { get; private set ; }
        public IUserRepo UserRepo { get; private set ; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProductRepo = new ProductRepo(_context);
            CategoryRepo = new CategoryRepo(_context);
            OrderRepo = new OrderRepo(_context); 
            UserRepo = new UserRepo(_context);
        }

    }
}
