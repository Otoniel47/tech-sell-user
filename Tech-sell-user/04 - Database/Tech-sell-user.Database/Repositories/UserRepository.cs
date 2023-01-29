using Microsoft.EntityFrameworkCore;
using Tech_sell_user.Database.Context;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TechSellUserContext context) : base(context)
        {
        }

        public async Task<bool> ExistAsync(string email)
        {
            return await Query().AnyAsync(x => x.Email == email);
        }
    }
}