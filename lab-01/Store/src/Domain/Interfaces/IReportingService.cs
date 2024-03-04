using Domain.Entities;

namespace Domain.Interfaces;
public interface IReportingService
{
    Task ReportIncome(int warehouseId, int productId, int quantity);
    Task ReportShipment(int warehouseId, int productId, int quantity);
    Task ReportInventory(Warehouse warehouse);
}
