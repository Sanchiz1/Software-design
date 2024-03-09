using Domain.Entities.WareHouseAggregate;

namespace Domain.Interfaces;
public interface IReportingService
{
    Task ReportIncome(int warehouseId, int productId, int quantity, string measurementUnits);
    Task ReportShipment(int warehouseId, int productId, int quantity, string measurementUnits);
    Task ReportInventory(Warehouse warehouse);
}
