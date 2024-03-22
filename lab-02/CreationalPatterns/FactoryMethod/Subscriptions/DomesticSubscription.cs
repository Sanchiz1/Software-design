using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Subscriptions;
public class DomesticSubscription : Subscription
{
    public DomesticSubscription(int userId, decimal monthlyPayment, int minimumPeriodMonths, IReadOnlyCollection<string> channels)
        : base(userId, monthlyPayment, minimumPeriodMonths, channels, SubscriptionType.Domestic) 
    {

    }

    public override string ToString()
    {
        return $"Domestic subscription: Monthly payment - {MonthlyPayment}, Minimum period - {MinimumPeriodMonths} months, channels - {Channels.Count()}";
    }
}
