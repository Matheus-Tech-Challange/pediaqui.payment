namespace Application.Features.Create;

public record CreatePaymentRequest : IRequest<string>
{
    public int NumeroPedido { get; set; }
    public decimal Valor { get; set; }
}
