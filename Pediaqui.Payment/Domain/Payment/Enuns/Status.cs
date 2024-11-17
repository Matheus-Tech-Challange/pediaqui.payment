using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment.Enuns;

public enum Status
{
    PENDING,
    APPROVED,
    FAIL
}

public static class PaymentExtension
{
    public static Status ToPaymentEnum(this string paymentStatus)
    {
        switch (paymentStatus)
        {
            case nameof(Status.PENDING):
                return Status.PENDING;
            case nameof(Status.APPROVED):
                return Status.APPROVED;
            case nameof(Status.FAIL):
                return Status.FAIL;
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentStatus));
        }
    }
}