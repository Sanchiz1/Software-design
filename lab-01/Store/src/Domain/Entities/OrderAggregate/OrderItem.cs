using Domain.Entities.ProductAggregate;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderAggregate;
public class OrderItem
{
    public int ProductId { get; private set; }
    public Product? Product { get; private set; }
    public Money Price { get; private set; }
    public int Discount { get; private set; } = 0;
    public decimal PriceWithDiscount => Price.Amount - Price.Amount * Discount / 100;
    public int Quantity { get; private set; }

    public OrderItem(int productId, Money price, int quantity = 1, int discount = 0)
    {
        if (!price.IsPositive())
            throw new ArgumentOutOfRangeException(nameof(price), price, "Product price must be between more than 0.");

        if (discount < 0 || discount > 99)
            throw new ArgumentOutOfRangeException(nameof(discount), discount, "Product discount must be between 0 and 99.");

        ProductId = productId;
        Price = price;
        Discount = discount;
        Quantity = quantity;
    }

    public OrderItem(Product product, int quantity = 1)
    {
        if (!product.Price.IsPositive())
            throw new ArgumentOutOfRangeException(nameof(product.Price), product.Price, "Product price must be between more than 0.");

        if (product.Discount < 0 || product.Discount > 99)
            throw new ArgumentOutOfRangeException(nameof(product.Discount), product.Discount, "Product discount must be between 0 and 99.");

        ProductId = product.Id;
        Price = product.Price;
        Discount = product.Discount;
        Quantity = quantity;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Product quantity must be 0 or more.");

        Quantity = quantity;
    }
}
