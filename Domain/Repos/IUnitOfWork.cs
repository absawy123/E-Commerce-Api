namespace Domain.Repos
{
    public interface IUnitOfWork
    {
        public IProductRepo ProductRepo { get; }
        public ICategoryRepo CategoryRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IUserRepo UserRepo { get; }
    }
}
