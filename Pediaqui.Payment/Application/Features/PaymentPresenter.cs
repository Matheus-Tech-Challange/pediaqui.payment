using AutoMapper;
using Domain.Payment.Entities;

namespace Application.Features;

public class PaymentPresenter
{
    public IMapper Mapper { get; set; }

    public PaymentPresenter(IMapper mapper)
    {
        Mapper = mapper;
    }

    public async Task<PaymentResponse> ToPaymentResponse(Payment payment)
    {
        var map = Mapper.Map<PaymentResponse>(payment);
        return await Task.FromResult(map);
    }
}
