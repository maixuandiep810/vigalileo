using Microsoft.Extensions.DependencyInjection;
using vigalileo.Services.System.Users;
using vigalileo.Data.Entities;
using Microsoft.AspNetCore.Identity;
using vigalileo.Data.EF;
using Microsoft.Extensions.Configuration;
using vigalileo.Utilities.Constants;
using Microsoft.EntityFrameworkCore;

namespace vigalileo.BackendApi.Extensions
{
    public static class ViServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<vigalileoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(SystemConstants.MAIN_CONNECTION_STRING)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<vigalileoDbContext>()
                .AddDefaultTokenProviders();
            return services;
        }

        public static IServiceCollection AddViServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddTransient<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            services.AddTransient<RoleManager<ApplicationRole>, RoleManager<ApplicationRole>>();
            return services;
        }
    }
}