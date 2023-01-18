using Application.Common.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure {

    public static class ConfigureServices {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            var webDbConnection = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ApplicationDbContext>(options => { options.UseNpgsql(webDbConnection); });
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }

}