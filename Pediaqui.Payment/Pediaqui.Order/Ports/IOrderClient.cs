using Refit;

namespace Pediaqui.Order.Ports;

public interface IOrderClient
{
    [Post("/api/atualizarPedidoPago/{pedidoId}")]
    public Task UpdateOrderToPaid([AliasAs("pedidoId")] int pedidoId);
}
