using Application.Contracts;
using Application.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application {

    public static class ConfigureServices {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IStudentCommand, StudentCommand>();

            return services;
        }
    }

}