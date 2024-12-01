using Domain.Payment.Entities;
using MongoDB.Bson;

namespace Domain.Payment.Ports;

public interface IPaymentRepository
{
    public Task<string> Create(Entities.Payment payment);
    public Task<Entities.Payment?> GetByPedido(int pedidoId);
    public Task<Entities.Payment> MarkAsPaid(string paymentID);
}
