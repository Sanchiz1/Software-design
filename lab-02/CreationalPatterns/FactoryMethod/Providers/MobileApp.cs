using FactoryMethod.Creator;
using FactoryMethod.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Providers;
public class MobileApp : ISubscriptionCreator
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
                return new DomesticSubscription(
                    userId,
                    1.99m, 1,
                    ["Channel 1", "Channel 2", "Channel 3", "Channel 4"]);
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
