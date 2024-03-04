using Domain.Common;
using Domain.Entities.WareHouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities.OrderAggregate;
public class Order : BaseEntity<int>
{
    public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
    public string ShipToAddress { get; private set; }
    public bool Accepted { get; private set; }
    private readonly List<OrderItem> _items = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalPrice => _items.Sum(i => i.PriceWithDiscount * i.Quantity);

    public Order(string shipToAddress, List<OrderItem> items)
    {
        ShipToAddress = shipToAddress;
        _items = items;
    }

    public void UpdateShipToAddress(string shipToAddress)
    {
        ShipToAddress = shipToAddress;
    }

    public void Accept()
    {
        Accepted = true;
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(OrderItem item)
    {
        _items.Remove(item);
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }
}
