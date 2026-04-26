using Microsoft.Extensions.DependencyInjection;
using POS.API.Repository;
using POS.API.Concrete;

namespace POS.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register repository implementations here
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Add additional repositories/services as needed:
            // services.AddScoped<IOtherRepository, OtherRepository>();

            return services;
        }
    }
}