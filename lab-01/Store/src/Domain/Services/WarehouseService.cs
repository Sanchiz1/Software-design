using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using SharedKernel;

namespace Domain.Services;
public class WarehouseService
{
    private readonly Warehouse _warehouse;
    private readonly IReportingService _reportingService;

    public WarehouseService(Warehouse warehouse, IReportingService reportingService)
    {
        _warehouse = warehouse;
        _reportingService = reportingService;
    }

    public Result<bool> AddProduct(int productId, string measurementUnits, int quantity = 1)
    {
        if (!_warehouse.Items.Any(i => i.ProductId == productId && i.MeasurementUnits == measurementUnits))
        {
            _warehouse.AddItem(new WarehouseItem(productId, quantity, measurementUnits));

            _reportingService.ReportIncome(_warehouse.Id, productId, quantity);

            return true;
        }

        var existingItem = _warehouse.Items.First(i => i.ProductId == productId);

        existingItem.SetQuantity(existingItem.Quantity + quantity);

        _reportingService.ReportIncome(_warehouse.Id, productId, quantity);

        return true;
    }

    public Result<bool> RemoveProduct(int productId, int quantity = 1)
    {
        var item = _warehouse.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null) return new NotFoundException("No such product in the warehouse");

        if (item.Quantity < quantity) return new ArgumentException($"Only {item.Quantity} products in the warehouse, trying to remove {quantity}");

        item.SetQuantity(item.Quantity - quantity);

        _warehouse.RemoveEmptyItems();

        return true;
    }
}
