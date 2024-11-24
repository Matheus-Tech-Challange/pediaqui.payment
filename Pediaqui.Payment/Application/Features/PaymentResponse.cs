using Domain.Payment.Enuns;

namespace Application.Features;

public record PaymentResponse
{
    public Guid Guid { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
}
