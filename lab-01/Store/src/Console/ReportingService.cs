using Domain.Entities;
using Domain.Interfaces;

namespace ConsoleApp;
public class ReportingService : IReportingService
{
    public async Task ReportIncome(int warehouseId, int productId, int quantity)
    {
        Console.WriteLine($"\nReport: Incoming product {productId} to the warehouse {warehouseId}. Quantity - {quantity}\n");
    }

    public async Task ReportShipment(int warehouseId, int productId, int quantity)
    {
        Console.WriteLine($"\nReport: Shipping product {productId} from the warehouse {warehouseId}. Quantity - {quantity}\n");
    }

    public async Task ReportInventory(Warehouse warehouse)
    {
        Console.WriteLine($"\n\n\n--------------------------------------------");
        Console.WriteLine($"Warehouse {warehouse.Id} - {warehouse.Name}\n");
        Console.WriteLine($"{warehouse.TotalItems} Products");
        foreach (var item in warehouse.Items)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine($"--------------------------------------------\n\n\n");
    }
}
