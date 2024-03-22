namespace FactoryMethod.Subscriptions;
public abstract class Subscription
{
    public int UserId { get; set; }
    public decimal MonthlyPayment {  get; set; }
    public int MinimumPeriodMonths {  get; set; }
    public IReadOnlyCollection<string> Channels { get; set;}
    public SubscriptionType Type { get; set;}

    public Subscription(int userId, decimal monthlyPayment, int minimumPeriodMonths, IReadOnlyCollection<string> channels, SubscriptionType type) 
    {
        if(monthlyPayment < 0)
            throw new ArgumentOutOfRangeException(nameof(monthlyPayment), monthlyPayment, "Payment cannot be less than 0");

        if (minimumPeriodMonths < 1)
            throw new ArgumentOutOfRangeException(nameof(MinimumPeriodMonths), MinimumPeriodMonths, "Subscribtion period cannot be less than 1 month");

        if (channels is null || channels.Count() == 0)
            throw new ArgumentNullException("Subscription cannot have no channels", nameof(channels));

        UserId = userId;
        MonthlyPayment = monthlyPayment;
        MinimumPeriodMonths = minimumPeriodMonths;
        Channels = channels;
        Type = type;
    }

    public abstract override string ToString();
}
public enum SubscriptionType
{
    Domestic,
    Educational,
    Premium
}