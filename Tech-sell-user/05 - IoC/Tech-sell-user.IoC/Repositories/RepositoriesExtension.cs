using Microsoft.Extensions.DependencyInjection;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Database.UnitOfWork;

namespace Tech_sell_user.IoC.Repositories
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}