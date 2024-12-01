namespace Application.Features.GetByPedido;

public class GetByPedidoRequest : IRequest<string>
{
    public int PedidoId { get; set; }
}
