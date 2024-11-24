using Domain.Payment.Ports;
using Pediaqui.Order.Ports;

namespace Application.Features.ReceivePayment;

public class ReceivePaymentHandler : IRequestHandler<ReceivePaymentRequest, PaymentResponse>
{
    private readonly IPaymentRepository paymentRepository;
    private readonly IOrderClient orderClient;
    private readonly PaymentPresenter paymentPresenter;
    private readonly NotificationContext notificationContext;

    public ReceivePaymentHandler(
        IPaymentRepository paymentRepository,
        IOrderClient orderClient,
        PaymentPresenter paymentPresenter,
        NotificationContext notificationContext)
    {
        this.paymentRepository = paymentRepository;
        this.orderClient = orderClient;
        this.paymentPresenter = paymentPresenter;
        this.notificationContext = notificationContext;
    }

    public async Task<PaymentResponse> Handle(ReceivePaymentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var p = await paymentRepository.MarkAsPaid(request.PaymentId!);
            await orderClient.UpdateOrderToPaid(p.PedidoId);
            return await paymentPresenter.ToPaymentResponse(p);
        }
        catch (Exception e)
        {
            notificationContext.AddNotification("falha ao receber pagamento", e.Message);
            return null!;
        }
    }
}
