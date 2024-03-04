using Domain.Common;

namespace Domain.Entities.WareHouseAggregate;

public class Warehouse : BaseEntity<int>
{
    public string Name { get; private set; }
    private List<WarehouseItem> _items = new List<WarehouseItem>();
    public IReadOnlyCollection<WarehouseItem> Items => _items.AsReadOnly();
    public int TotalItems => _items.Sum(i => i.Quantity);

    public Warehouse(string name)
    {
        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddItem(WarehouseItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(WarehouseItem item)
    {
        _items.Remove(item);
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }
}
