﻿using Domain.Payment.Ports;

namespace Application.Features.GetByPedido;

public class GetByPedidoHandler : IRequestHandler<GetByPedidoRequest, PaymentResponse>
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

    public async Task<PaymentResponse> Handle(GetByPedidoRequest request, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByPedido(request.PedidoId);
        return await paymentPresenter.ToPaymentResponse(payment);
    }
}