using Domain.Common;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;

namespace Domain.Entities.WareHouseAggregate;

public class Warehouse : BaseEntity<int>
{
    public string Name { get; private set; }

    private readonly List<WarehouseItem> _items = new List<WarehouseItem>();
    public IReadOnlyCollection<WarehouseItem> Items => _items.AsReadOnly();
    public int TotalItems => Items.Sum(i => i.Quantity);


    public Warehouse(string name)
    {
        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddItem(int productId, string measurementUnits, int quantity = 1)
    {
        var Item = _items.FirstOrDefault(i => i.ProductId == productId);

        if (Item == null)
        {
            _items.Add(new WarehouseItem(productId, quantity, measurementUnits));

            return;
        }

        Item.SetQuantity(Item.Quantity + quantity);
    }

    public void RemoveItem(int productId, int quantity = 1)
    {
        var Item = _items.FirstOrDefault(i => i.ProductId == productId);

        if (Item == null || Item.Quantity < quantity)
        {
            throw new ArgumentException($"Warehouse does not have {quantity} products {productId}.");
        }

        Item.SetQuantity(Item.Quantity - quantity);

        RemoveEmptyItems();
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }
}
