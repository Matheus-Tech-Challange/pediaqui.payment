using Domain.Common.Entities;
using Domain.Payment.Enuns;
using Domain.Payment.Factories;

namespace Domain.Payment.Entities;

public class Payment : Entity
{
    public Payment(int pedidoId, decimal valor)
    {
        PaymentId = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Status = Status.PENDING;
        PedidoId = pedidoId;
        Valor = valor;

        Validar<Payment>(this, PaymentValidatorFactory.Create());
    }

    public Guid PaymentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public int PedidoId { get; set; }
    public decimal Valor { get; set; }
}
