using Refit;

namespace Pediaqui.Order.Ports;

public interface IOrderClient
{
    [Post("/api/pedido/receber/{pedidoId}")]
    public Task UpdateOrderToPaid([AliasAs("pedidoId")] int pedidoId);
}
