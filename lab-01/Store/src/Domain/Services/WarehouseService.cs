using Domain.Common.Exceptions;
using Domain.Entities;
using Domain.Entities.WareHouseAggregate;
using Domain.Interfaces;
using SharedKernel;

namespace Domain.Services;
public class WarehouseService : IWarehouseService
{
    private readonly IReportingService _reportingService;

    public WarehouseService(IReportingService reportingService)
    {
        _reportingService = reportingService;
    }

    public Result<Warehouse> AddProduct(Warehouse warehouse, int productId, string measurementUnits, int quantity = 1)
    {
        if (!warehouse.Items.Any(i => i.ProductId == productId && i.MeasurementUnits == measurementUnits))
        {
            warehouse.AddItem(new WarehouseItem(productId, quantity, measurementUnits));

            _reportingService.ReportIncome(warehouse.Id, productId, quantity);

            return warehouse;
        }

        var existingItem = warehouse.Items.First(i => i.ProductId == productId);

        existingItem.SetQuantity(existingItem.Quantity + quantity);

        _reportingService.ReportIncome(warehouse.Id, productId, quantity);

        return warehouse;
    }

    public Result<Warehouse> RemoveProduct(Warehouse warehouse, int productId, int quantity = 1)
    {
        var item = warehouse.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null) 
            return new NotFoundException("No such product in the warehouse.");

        if (item.Quantity < quantity) 
            return new ArgumentException($"Only {item.Quantity} products in the warehouse, trying to remove {quantity}.");

        item.SetQuantity(item.Quantity - quantity);

        warehouse.RemoveEmptyItems();

        return warehouse;
    }
}
