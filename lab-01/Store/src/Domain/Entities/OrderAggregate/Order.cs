using Domain.Common;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WareHouseAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities.OrderAggregate;
public class Order : BaseEntity<int>
{
    public DateTime OrderDate { get; private set; }
    public string ShipToAddress { get; private set; }
    public bool Accepted { get; private set; }
    private readonly List<OrderItem> _items = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalPrice => Items.Sum(i => i.PriceWithDiscount * i.Quantity);

    public Order(string shipToAddress)
    {
        ShipToAddress = shipToAddress;
    }

    public void UpdateShipToAddress(string shipToAddress)
    {
        ShipToAddress = shipToAddress;
    }

    public void Accept()
    {
        if (_items.Count() < 1)
            throw new ArgumentException("Cannot accept empty order.");

        Accepted = true;
        OrderDate = DateTime.UtcNow;
    }

    public void AddItem(Product Product, int quantity = 1)
    {
        ThrowIfEditingAccepted();

        if (IsDifferentCurrency(Product.Price.CurrencyCode))
            throw new ArgumentException("Cannot order products with prices in different currencies.");

        var Item = _items.FirstOrDefault(i => i.ProductId == Product.Id);

        if (Item == null)
        {
            _items.Add(new OrderItem(Product, quantity));

            return;
        }

        Item.SetQuantity(Item.Quantity + quantity);
    }

    public void RemoveItem(int productId, int quantity = 1)
    {
        ThrowIfEditingAccepted();

        var Item = _items.FirstOrDefault(i => i.ProductId == productId);

        if (Item == null || Item.Quantity < quantity)
        {
            throw new ArgumentException($"Order does not have {quantity} products {productId}.");
        }

        Item.SetQuantity(Item.Quantity - quantity);

        RemoveEmptyItems();
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }

    public bool IsDifferentCurrency(string currency)
    {
        var item = _items.FirstOrDefault();

        return item != null && item.Price.CurrencyCode != currency;            
    }

    public void ThrowIfEditingAccepted()
    {
        if (Accepted)
            throw new ArgumentException("Cannot edit accepted order.");
    }

    public override string ToString()
    {
        return $"Order {Id}, {Items.Count} items, total - {TotalPrice}, is accepted - {Accepted}";
    }
}
