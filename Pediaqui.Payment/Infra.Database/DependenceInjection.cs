using Domain.Payment.Ports;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database;

public static class DependenceInjection
{
    public static IServiceCollection AddInfraData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPaymentRepository, PaymentRespository>();
        services.AddDbContext<DatabaseContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Default");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        return services;
    }
}
