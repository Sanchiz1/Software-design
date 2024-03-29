﻿using Domain.Common;

namespace Domain.ValueObjects;

public class Money : ValueObject
{
    public int CentAmount { get; private set; }
    public decimal Amount => (decimal)(CentAmount / 100.0);
    public string CurrencyCode { get; private set; }

    private Money(int centAmount, string currencyCode)
    {
        SetCentAmount(centAmount);
        CurrencyCode = currencyCode;
    }

    private Money(decimal amount, string currencyCode)
    {
        SetCentAmount((int)(amount * 100));
        CurrencyCode = currencyCode;
    }

    public void AddAmount(decimal amount) =>
        SetCentAmount(CentAmount + (int)(amount * 100));

    public void AddAmountFromCents(int centAmount) =>
        SetCentAmount(CentAmount + centAmount);

    public void UpdateAmount(decimal amount) =>
        SetCentAmount((int)(amount * 100));

    public void UpdateAmountFromCents(int centAmount) =>
        SetCentAmount(centAmount);

    public void UpdateCurrencyCode(string currencyCode) =>
        CurrencyCode = currencyCode;

    private void SetCentAmount(int amount)
    {
        ValidateAmount(amount);
        CentAmount = amount;
    }

    public override string ToString()
    {
        return $"{Amount} {CurrencyCode}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CentAmount;
        yield return CurrencyCode;
    }

    public static void ValidateAmount(int amount)
    {
        if(amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount cannot be negative.");
    }

    public static Money CreateMoneyFromCents(int centAmount, string currencyCode) =>
        new Money(centAmount, currencyCode);

    public static Money CreateMoney(decimal amount, string currencyCode) =>
        new Money(amount, currencyCode);
}