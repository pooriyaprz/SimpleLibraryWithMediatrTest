using Application.Common.Interfaces;
using LibraryApplication.Services;

namespace LibraryApplication
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();


            // Customise default API behaviour



            return services;
        }
    }
}
