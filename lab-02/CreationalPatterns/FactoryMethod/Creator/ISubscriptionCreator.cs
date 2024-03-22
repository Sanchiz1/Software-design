using FactoryMethod.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Creator;
public interface ISubscriptionCreator
{
    Subscription CreateSubscription(int userId, SubscriptionType type);
}
