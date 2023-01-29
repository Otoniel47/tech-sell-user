using Microsoft.Extensions.DependencyInjection;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Application.Services;

namespace Tech_sell_user.IoC.Services
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IDateTimeService, DateTimeService>();
        }
    }
}