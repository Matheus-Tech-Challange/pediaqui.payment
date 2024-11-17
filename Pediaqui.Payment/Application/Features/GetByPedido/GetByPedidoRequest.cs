namespace Application.Features.GetByPedido;

public class GetByPedidoRequest : IRequest<PaymentResponse>
{
    public int PedidoId { get; set; }
}
