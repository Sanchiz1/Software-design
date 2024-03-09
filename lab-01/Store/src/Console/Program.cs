using Domain.Entities;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WareHouseAggregate;
using Domain.Interfaces;
using Domain.Services;
using Domain.ValueObjects;

namespace ConsoleApp;
internal class Program
{
    private static async Task Main(string[] args)
    {
        await DemonstrateWarehouseFunctionality();
        await DemonstrateOrderFunctionality();
    }

    public static async Task DemonstrateWarehouseFunctionality()
    {
        Console.WriteLine("\n\nWarehouse functionality");

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
        IWarehouseService _warehouseService = new WarehouseService(new ReportingService());

        _warehouseService.RemoveProduct(warehouse, ApplesProduct.Id, 1)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(warehouse, ApplesProduct.Id, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(warehouse, ApplesProduct.Id, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        await _reportingService.ReportInventory(warehouse);

        _warehouseService.RemoveProduct(warehouse, ApplesProduct.Id, 11)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.RemoveProduct(warehouse, ApplesProduct.Id, 3)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(warehouse, BreadProduct.Id, "kgs", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(warehouse, BreadProduct.Id, "kgs", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        await _reportingService.ReportInventory(warehouse);
    }


    public static async Task DemonstrateOrderFunctionality()
    {
        Console.WriteLine("\n\nOrder functionality");

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
        IWarehouseService _warehouseService = new WarehouseService(new ReportingService());

        _warehouseService.AddProduct(warehouse, ApplesProduct.Id, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _warehouseService.AddProduct(warehouse, ApplesProduct.Id, "packages", 5)
            .OnFail(ex => Console.WriteLine(ex.Message));

        await _reportingService.ReportInventory(warehouse);

        IOrderService _orderService = new OrderService(_warehouseService);

        var order = new Order("Street 1")
        {
            Id = 1
        };

        Console.WriteLine(order);

        var resMessage = _orderService.AddProduct(order, ApplesProduct, 11).Match<string>(
            res => res.ToString(),
            ex => ex.Message);

        Console.WriteLine(resMessage);

        resMessage = _orderService.AcceptOrder(order, warehouse).Match<string>(
            res => res.ToString(),
            ex => ex.Message);

        Console.WriteLine(resMessage);

        _orderService.SetProductQuantity(order, ApplesProduct.Id, 10)
            .OnFail(ex => Console.WriteLine(ex.Message));

        _orderService.AcceptOrder(order, warehouse)
            .OnFail(ex => Console.WriteLine(ex.Message));

        Console.WriteLine(order);

        await _reportingService.ReportInventory(warehouse);
    }
}