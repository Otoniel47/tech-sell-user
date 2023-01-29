using Microsoft.EntityFrameworkCore;
using Tech_sell_user.Database.Mapping;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Database.Context
{
    public class TechSellUserContext : DbContext
    {
        public TechSellUserContext(DbContextOptions<TechSellUserContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class => Set<T>();
        public bool HasChanges() => ChangeTracker.HasChanges();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}