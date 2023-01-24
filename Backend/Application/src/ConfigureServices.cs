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

            services.AddScoped<IProfessorQuery, ProfessorQuery>();
            services.AddScoped<IProfessorCommand, ProfessorCommand>();

            services.AddScoped<IProfessorDisciplineQuery, ProfessorDisciplineQuery>();
            services.AddScoped<IProfessorDisciplineCommand, ProfessorDisciplineCommand>();

            services.AddScoped<IClassbookQuery, ClassbookQuery>();
            services.AddScoped<IClassbookCommand, ClassbookCommand>();

            return services;
        }
    }

}