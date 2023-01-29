using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application.Interfaces
{
    public interface IUserService
    {
        Task DeleteAsync(string id);
        
        Task<List<User>> GetAsync();

        User? GetByEmailAsync(string email);
        
        Task<User?> GetByIdAsync(string id);
        
        Task SaveAsync(User user);
        
        Task UpdateAsync(User user);
    }
}