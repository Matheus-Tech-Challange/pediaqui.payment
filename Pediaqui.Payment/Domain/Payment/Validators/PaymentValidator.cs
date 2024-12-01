using Domain.Common.Ports;
using Domain.Payment.Entities;
using FluentValidation;

namespace Domain.Payment.Validators;

public class PaymentValidator : IValidatorEntity<Entities.Payment>
{
    public void Validate(Entities.Payment entity)
    {
        var validationResult = new PaymentFluentValidator().Validate(entity);

        foreach (var error in validationResult.Errors)
        {
            entity.AddError(error.ErrorCode, error.ErrorMessage);
        }
    }

    public class PaymentFluentValidator : AbstractValidator<Entities.Payment>
    {
        public PaymentFluentValidator()
        {

            RuleFor(p => p.PedidoId)
                .NotNull()
                .WithMessage("Número do pedido é obrigatório.");

            RuleFor(p => p.Valor)
                .GreaterThan(0)
                .WithMessage("Valor do pagamento não pode ser zero.");
        }
    }
}

