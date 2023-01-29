using Tech_sell_user.Database.Context;

namespace Tech_sell_user.Database.Interface
{
    public interface IUnitOfWork
    {
        public TechSellUserContext Context { get; }

        public IUserRepository UserRepository { get; }

        Task CommitAsync();
    }
}