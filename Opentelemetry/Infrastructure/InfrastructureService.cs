using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roller.Appication.ContractRepo;
using Roller.Infrastructure.Repositories;
using Roller.Infrastructure.Database;

namespace Roller.Infrastructure
{
    public static class InfrastructureService 
{
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRollRepository, RollRepository>();

            var ConnectionString = configuration.GetConnectionString("rollerdb");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(ConnectionString);
            });
            return services;
        }
    }
}