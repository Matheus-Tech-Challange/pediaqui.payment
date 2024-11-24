using AutoMapper;
using Domain.Payment.Entities;
using Domain.Payment.Enuns;

namespace Application.Features;

public class PaymentResponseMapper : Profile
{
	public PaymentResponseMapper()
	{
		CreateMap<Payment, PaymentResponse>()
			.ForMember(dest => dest.Status, m => m.MapFrom(p => p.Status.ToPaymentText()));
	}
}
