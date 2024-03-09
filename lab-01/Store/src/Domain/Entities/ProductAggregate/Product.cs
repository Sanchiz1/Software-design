using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities.ProductAggregate;

public class Product : BaseEntity<int>
{
    public string Title { get; private set; }
    public string Manufacturer { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; }
    public int Discount { get; private set; } = 0;
    public decimal PriceWithDiscount => Price.Amount - Price.Amount * Discount / 100;

    public Product(string title, string manufacturer, string description, Money price, int discount = 0)
    {
        ValidateDiscount(discount);
        Title = title;
        Manufacturer = manufacturer;
        Description = description;
        Price = price;
        Discount = discount;
    }

    public Product(string title, string manufacturer, Money price, int discount = 0)
    {
        ValidateDiscount(discount);
        Title = title;
        Manufacturer = manufacturer;
        Price = price;
        Discount = discount;
    }

    public void UpdateDetails(string title, string manufacturer, string description)
    {
        Title = title;
        Manufacturer = manufacturer;
        Description = description;
    }

    public void UpdateDiscount(int discount)
    {
        ValidateDiscount(discount);
        Discount = discount;
    }

    public override string ToString()
    {
        return $"{Title} ({Manufacturer}) - {PriceWithDiscount} {Price.CurrencyCode}";
    }

    private static void ValidateDiscount(int discount)
    {
        if (discount < 0 || discount > 99)
            throw new ArgumentOutOfRangeException(nameof(discount), discount, "Product discount must be between 0 and 99.");
    }
}