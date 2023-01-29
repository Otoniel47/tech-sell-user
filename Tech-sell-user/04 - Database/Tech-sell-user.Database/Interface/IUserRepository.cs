using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Database.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistAsync(string email);
    }
}