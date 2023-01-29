using Tech_sell_user.Database.Context;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Database.Repositories;

namespace Tech_sell_user.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TechSellUserContext _context;

        public UnitOfWork(TechSellUserContext context)
        {
            _context = context;
        }

        public TechSellUserContext Context => _context;

        public IUserRepository UserRepository => new UserRepository(_context);

        public Task CommitAsync() => _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}