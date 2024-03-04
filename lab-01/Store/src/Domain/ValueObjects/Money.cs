using Domain.Common;

namespace Domain.ValueObjects;

public class Money : ValueObject
{
    public int CentAmount { get; private set; }
    public decimal Amount => (decimal)(CentAmount / 100.0);
    public string CurrencyCode { get; private set; }

    private Money(int centAmount, string currencyCode)
    {
        CentAmount = centAmount;
        CurrencyCode = currencyCode;
    }

    private Money(decimal amount, string currencyCode)
    {
        CentAmount = (int)(amount * 100);
        CurrencyCode = currencyCode;
    }

    public bool IsPositive() =>
        CentAmount > 0;

    public bool IsNegative() =>
        CentAmount < 0;

    public void AddAmount(decimal amount) =>
        CentAmount += (int)(amount * 100);

    public void AddAmountFromCents(int centAmount) =>
        CentAmount += centAmount;

    public void UpdateAmount(decimal amount) =>
        CentAmount = (int)(amount * 100);

    public void UpdateAmountInCents(int centAmount) =>
        CentAmount = centAmount;

    public void UpdateCurrencyCode(string currencyCode) =>
        CurrencyCode = currencyCode;

    public override string ToString()
    {
        return $"{Amount} {CurrencyCode}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CentAmount;
        yield return CurrencyCode;
    }

    public static Money CreateMoneyFromCents(int centAmount, string currencyCode) =>
        new Money(centAmount, currencyCode);

    public static Money CreateMoney(decimal amount, string currencyCode) =>
        new Money(amount, currencyCode);
}