using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tech_sell_user.Application.Profiles;

namespace Tech_sell_user.IoC.Mapper
{
    public static class MapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            services.AddSingleton(sp => mapper.CreateMapper());
        }
    }
}