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

    public static string ToPaymentText(this Status paymentStatus)
    {
        switch (paymentStatus)
        {
            case Status.PENDING:
                return nameof(Status.PENDING);
            case Status.APPROVED:
                return nameof(Status.APPROVED);
            case Status.FAIL:
                return nameof(Status.FAIL);
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentStatus));
        }
    }
}