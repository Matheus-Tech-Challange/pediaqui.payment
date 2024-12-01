using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pediaqui.Order.Ports;
using Refit;

namespace Pediaqui.Order;

public record OrderService(string URL, int port);

public static class DependenceInjection
{
    public static IServiceCollection AddOrderService(this IServiceCollection services, IConfiguration configuration)
    {
        OrderService service = configuration.GetSection(nameof(OrderService)).Get<OrderService>()!;

        if (service is null) throw new ArgumentNullException(nameof(OrderService));

        services
            .AddRefitClient<IOrderClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{service.URL}:{service.port}"));

        return services;
    }
}
