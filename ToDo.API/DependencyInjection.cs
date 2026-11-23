using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Persistence.Entities;

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

            return services;
        }

    }
}
