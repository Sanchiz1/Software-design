using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace ConsoleApp;
internal class Program
{
    private static async Task Main(string[] args)
    {
        await DemonstrateWarehouseFunctionality();
    }

    public static async Task DemonstrateWarehouseFunctionality()
    {
        var price1 = Money.CreateMoneyFromCents(400, "USD");
        var price2 = Money.CreateMoney(1.50m, "USD");

        var BreadProduct = new Product("White bread", "Dave`s Bread", price1, 50)
        {
            Id = 1
        };

        var ApplesProduct = new Product("Red apples", "Your Farm", price2)
        {
            Id = 2
        };

        Console.WriteLine(BreadProduct.ToString());
        Console.WriteLine(ApplesProduct.ToString());
        Console.WriteLine();

        var unit = new WarehouseItem(ApplesProduct, 25, "kgs");

        Console.WriteLine($"{unit}. Total price = {unit.GetTotalPrice()}");
        Console.WriteLine();

        var warehouse = new Warehouse("Warehouse #1")
        {
            Id = 1
        };

        var _reportingService = new ReportingService();
        var _warehouseService = new WarehouseService(warehouse, new ReportingService());

        _warehouseService.RemoveProduct(1, 1)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(1, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(1, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        await _reportingService.ReportInventory(warehouse);

        _warehouseService.RemoveProduct(1, 11)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.RemoveProduct(1, 3)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(2, "kgs", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(2, "kgs", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        await _reportingService.ReportInventory(warehouse);
    }
}