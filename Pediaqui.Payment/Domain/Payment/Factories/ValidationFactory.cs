using Domain.Common.Ports;
using Domain.Payment.Validators;

namespace Domain.Payment.Factories;

public static class PaymentValidatorFactory
{
    public static IValidatorEntity<Entities.Payment> Create()
    {
        return new PaymentValidator();
    }
}
