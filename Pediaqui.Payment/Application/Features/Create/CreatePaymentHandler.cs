using Domain.Payment.Entities;
using Domain.Payment.Ports;

namespace Application.Features.Create;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentRequest, string>
{
    public readonly IPaymentRepository paymentRepository;
    public readonly NotificationContext notification;

    public CreatePaymentHandler(
        IPaymentRepository paymentRepository,
        NotificationContext notification)
    {
        this.paymentRepository = paymentRepository;
        this.notification = notification;
    }

    public async Task<string> Handle(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        var payment = new Payment(request.NumeroPedido, request.Valor);

        if (payment.Invalid)
        {
            notification.AddNotification("InvalidPayment", "Pagamento inválido.");
            return string.Empty;
        }

        var guid = await paymentRepository.Create(payment);
        return guid.ToString();
    }
}
