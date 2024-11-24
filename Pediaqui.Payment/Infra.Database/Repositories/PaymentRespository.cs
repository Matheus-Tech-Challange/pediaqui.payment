using Domain.Payment.Entities;
using Domain.Payment.Ports;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class PaymentRespository : IPaymentRepository
{
    private readonly DatabaseContext _context;

    public PaymentRespository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        var result = await _context.SaveChangesAsync();

        return payment.Guid;
    }

    public async Task<Payment> GetByPedido(int pedidoId)
    {
        var p = await _context.Payments
            .Where(p => p.PedidoId == pedidoId)
            .FirstAsync();

        return p;
    }

    public async Task<Payment> MarkAsPaid(string paymentID)
    {
        var p = await _context.Payments
            .Where(p => p.Guid.ToString() == paymentID)
            .FirstAsync();

        p.Status = Domain.Payment.Enuns.Status.APPROVED;
        _context.Payments.Update(p);
        _context.SaveChanges();

        return p;
    }
}
