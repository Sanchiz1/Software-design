using FactoryMethod.Creator;
using FactoryMethod.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FactoryMethod.Subscriptions.Subscription;

namespace FactoryMethod.Providers;
public class ManagerCall : ISubscriptionCreator
{
    public Subscription CreateSubscription(int userId, SubscriptionType type)
    {
        switch (type)
        {
            case SubscriptionType.Domestic:
                return new DomesticSubscription(
                    userId,
                    4.99m, 1,
                    ["Channel 1", "Channel 2", "Channel 3"]);

            case SubscriptionType.Educational:
                throw new ArgumentException("Creating educational subscription not supported by manager call");

            case SubscriptionType.Premium:
                return new PremiumSubscription(
                    userId,
                    9.99m, 3,
                    ["Channel 1", "Channel 2", "Channel 3", "Channel 4", "Channel 5"]);

            default:
                throw new ArgumentException("Unsupported subscription type", nameof(type));
        }
    }
}
