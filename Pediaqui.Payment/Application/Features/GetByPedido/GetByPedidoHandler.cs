using Domain.Payment.Enuns;
using Domain.Payment.Ports;

namespace Application.Features.GetByPedido;

public class GetByPedidoHandler : IRequestHandler<GetByPedidoRequest, string>
{
    public readonly IPaymentRepository paymentRepository;
    public readonly NotificationContext notification;
    public readonly PaymentPresenter paymentPresenter;

    public GetByPedidoHandler(
        IPaymentRepository paymentRepository,
        NotificationContext notification,
        PaymentPresenter paymentPresenter)
    {
        this.paymentRepository = paymentRepository;
        this.notification = notification;
        this.paymentPresenter = paymentPresenter;
    }

    public async Task<string> Handle(GetByPedidoRequest request, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByPedido(request.PedidoId);

        if (payment == null)
        {
            notification.AddNotification("Pedido não encontrado", "Nenhum pagamento encontrado para o pedido informado.");
            return null!;
        }

        return payment.Status.ToPaymentText();
    }
}
