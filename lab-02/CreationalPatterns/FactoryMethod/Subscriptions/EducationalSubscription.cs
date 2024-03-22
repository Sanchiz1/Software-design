using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Subscriptions;
internal class EducationalSubscription : Subscription
{
    public EducationalSubscription(int userId, decimal monthlyPayment, int minimumPeriodMonths, IReadOnlyCollection<string> channels)
        : base(userId, monthlyPayment, minimumPeriodMonths, channels, SubscriptionType.Educational)
    {

    }

    public override string ToString()
    {
        return $"Educational subscription: Monthly payment - {MonthlyPayment}, Minimum period - {MinimumPeriodMonths} months, channels - {Channels.Count()}";
    }
}
