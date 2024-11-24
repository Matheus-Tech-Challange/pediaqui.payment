using Domain.Payment.Entities;
using Domain.Payment.Ports;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Infra.Database.Repositories;

public class PaymentRespository : IPaymentRepository
{
    private readonly DatabaseContext _context;

    public PaymentRespository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<string> Create(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        var result = await _context.SaveChangesAsync();

        return payment.PaymentId.ToString();
    }

    public async Task<Payment?> GetByPedido(int pedidoId)
    {
        var p = await _context.Payments
            .Where(p => p.PedidoId == pedidoId)
            .FirstOrDefaultAsync();

        return p;
    }

    public async Task<Payment> MarkAsPaid(string paymentID)
    {
        var p = await _context.Payments
            .Where(p => p.PaymentId.ToString() == paymentID)
            .FirstAsync();

        p.Status = Domain.Payment.Enuns.Status.APPROVED;
        _context.Payments.Update(p);
        _context.SaveChanges();

        return p;
    }
}
