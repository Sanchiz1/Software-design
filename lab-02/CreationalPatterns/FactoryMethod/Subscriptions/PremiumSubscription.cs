using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Subscriptions;
public class PremiumSubscription : Subscription
{
    public PremiumSubscription(int userId, decimal monthlyPayment, int minimumPeriodMonths, IReadOnlyCollection<string> channels)
        : base(userId, monthlyPayment, minimumPeriodMonths, channels, SubscriptionType.Premium)
    {

    }

    public override string ToString()
    {
        return $"Premium subscription: Monthly payment - {MonthlyPayment}, Minimum period - {MinimumPeriodMonths} months, channels - {Channels.Count()}";
    }
}
