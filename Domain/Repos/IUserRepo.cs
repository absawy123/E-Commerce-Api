using Domain.Entities;

namespace Domain.Repos
{
    public interface IUserRepo 
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    }
}
