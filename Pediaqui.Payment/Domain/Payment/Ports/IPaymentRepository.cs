using Domain.Payment.Entities;

namespace Domain.Payment.Ports;

public interface IPaymentRepository
{
    public Task<Guid> Create(Entities.Payment payment);
    public Task<Entities.Payment> GetByPedido(int pedidoId);
}
