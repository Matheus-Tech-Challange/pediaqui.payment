using Domain.Payment.Ports;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database;

public static class DependenceInjection
{
    public static IServiceCollection AddInfraData(this IServiceCollection services, MongoDBSettings mongoDBSettings)
    {
        services.AddScoped<IPaymentRepository, PaymentRespository>();

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseMongoDB(mongoDBSettings.URI, mongoDBSettings.DatabaseName);
        });

        return services;
    }
}
