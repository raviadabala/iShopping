using iShopping.Api.Profiles;

namespace iShopping.Api.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfiles));
            return services;
        }
    }
}
