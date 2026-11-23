using Microsoft.EntityFrameworkCore;
using ToDo.Application;
using ToDo.Application.Contracts;
using ToDo.Application.Implementation;
using ToDo.Domain.RepositoryInterface;
using ToDo.Infrastructure;
using ToDo.Infrastructure.Persistence.Entities;
using ToDo.Infrastructure.Repository;

namespace ToDo.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<ToDoAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // register Automapper only at infra layer
            services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = configuration.GetValue<string>("AutomapperKey");
            }, typeof(InfraAssemblyMarker).Assembly);

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddApplication(
            this IServiceCollection services, IConfiguration configuration)
        {
            // register Automapper only at infra layer
            services.AddAutoMapper(cfg =>
            {
                cfg.LicenseKey = configuration.GetValue<string>("AutomapperKey");
            }, typeof(ApplicationAssemblyMarker).Assembly);

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
