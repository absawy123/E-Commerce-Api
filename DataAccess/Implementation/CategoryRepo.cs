using DataAccess.Data;
using Domain.Entities;
using Domain.Repos;

namespace DataAccess.Implementation
{
    public class CategoryRepo : GenericRepo<Category> , ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context):base(context) 
        {
            _context = context;
        }


    }
}
