using Application.Contracts;
using Application.Contracts.Queries;
using Application.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application {

    public static class ConfigureServices {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IStudentQuery, StudentQuery>();
            services.AddScoped<IStudentCommand, StudentCommand>();

            services.AddScoped<IDisciplineQuery, DisciplineQuery>();
            services.AddScoped<IDisciplineCommand, DisciplineCommand>();

            return services;
        }
    }

}