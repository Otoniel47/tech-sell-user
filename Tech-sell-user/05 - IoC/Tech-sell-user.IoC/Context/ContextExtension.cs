using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tech_sell_user.Database.Context;

namespace Tech_sell_user.IoC.Context
{
    public static class ContextExtension
    {
        public static void AddDatabase(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<TechSellUserContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}