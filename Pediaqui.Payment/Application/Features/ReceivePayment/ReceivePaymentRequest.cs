namespace Application.Features.ReceivePayment;

public class ReceivePaymentRequest : IRequest<PaymentResponse>
{
    public string? PaymentId { get; set; }
}
