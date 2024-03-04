using Domain.Common;
using Domain.Entities.ProductAggregate;

namespace Domain.Entities.WareHouseAggregate;
public class WarehouseItem : BaseEntity<int>
{
    public int ProductId { get; private set; }
    public Product? Product { get; private set; }
    public string MeasurementUnits { get; private set; }
    public int Quantity { get; private set; }

    public WarehouseItem(int productId, int quantity, string measurementUnits)
    {
        ProductId = productId;
        MeasurementUnits = measurementUnits;
        SetQuantity(quantity);
    }

    public WarehouseItem(Product product, int quantity, string measurementUnits)
    {
        ProductId = product.Id;
        Product = product;
        MeasurementUnits = measurementUnits;
        SetQuantity(quantity);
    }

    void UpdateMeasurementUnits(string measurementUnits)
    {
        MeasurementUnits = measurementUnits;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Product quantity must be 0 or more.");

        Quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        if (Product is null)
            throw new ArgumentNullException(nameof(Product));

        return Product.PriceWithDiscount * Quantity;
    }

    public override string ToString()
    {
        return $"Product {ProductId}, quantity - {Quantity} {MeasurementUnits}";
    }
}
