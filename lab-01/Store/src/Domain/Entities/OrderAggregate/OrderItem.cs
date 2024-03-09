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
        if (discount < 0 || discount > 99)
            throw new ArgumentOutOfRangeException(nameof(discount), discount, "Product discount must be between 0 and 99.");

        ProductId = productId;
        Price = price;
        Discount = discount;
        SetQuantity(quantity);
    }

    public OrderItem(Product product, int quantity = 1)
    {
        ProductId = product.Id;
        Price = product.Price;
        Discount = product.Discount;
        SetQuantity(quantity);
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Product quantity must be 0 or more.");

        Quantity = quantity;
    }
}
