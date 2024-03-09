## Warehouse

### KISS

Патерн KISS було використано при написанні класу ***Money***, замість написання окремих полів для цілої та дробової частини було створено одне поле для суми у копійках (сума * 100) та поле суми (сума у копійках / 100). Завдяки цьому немає потреби в окремій валідації дробової частини, переведення з дробової частини у цілу під час операцій додавання/віднімання, зручно зберігати в базу даних у майбутньому.

```C#
public int CentAmount { get; private set; }
public decimal Amount => (decimal)(CentAmount / 100.0);
```

### DRY

Патерн DRY було використано при написанні класу ***Money***, було створено метод для валідації суми та встановлення суми, в середині якого відбувався виклик методу валідації. Завдяки цьому відпала потреба написання нового коду для валідації у кожному методі та конструкторі класу де відбувається встановлення суми.

```C#
public static void ValidateAmount(int amount)
{
    if(amount < 0)
        throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount cannot be negative.");
}
```

```C#
private void SetAmount(int amount)
{
    ValidateAmount(amount);
    SetCentAmount = amount;
}
```

```C#
private Money(int centAmount, string currencyCode)
{
    SetCentAmount(centAmount);
    CurrencyCode = currencyCode;
}

public void UpdateAmount(decimal amount) =>
    SetCentAmount((int)(amount * 100));
```

### Program to Interfaces not Implementations, DIP

Патерн DIP було використано при написанні класу ***WarehouseService***. У завданні було сказано про створення звітності для товару на складі, було вирішено створити окремий сервіс для роботи зі складом та окремий сервіс ***IReportingService***, який буде використовуватися для звітності та використовуватися сервісом ***WarehouseService***.

```C#
private readonly IReportingService _reportingService;

public WarehouseService(IReportingService reportingService)
{
    _reportingService = reportingService;
}

public Result<Warehouse> AddProduct(Warehouse warehouse, int productId, string measurementUnits, int quantity = 1)
{
    warehouse.AddItem(productId, measurementUnits, quantity);

    _reportingService.ReportIncome(warehouse.Id, productId, quantity, measurementUnits);

    return warehouse;
}
```

Було використано патерн Program to Interfaces not Implementations, а саме в бібліотеці надано сервіс для звітування тільки у вигляді інтерфейсу. Через це інтерфейс можна реалізувати як завгодно, залежно від потреб програми, наприклад ***ConsoleApp*** має реалізацію у вигляді виведення повіддомлень у консоль, але будь яка інша програма може реалізувати вивід у потрібному форматі.

```C#
public interface IReportingService
{
    Task ReportIncome(int warehouseId, int productId, int quantity, string measurementUnits);
    Task ReportShipment(int warehouseId, int productId, int quantity, string measurementUnits);
    Task ReportInventory(Warehouse warehouse);
}
```


```C#
public class ReportingService : IReportingService
{
    public async Task ReportIncome(int warehouseId, int productId, int quantity, string measurementUnits)
    {
        Console.WriteLine($"\nReport: Incoming product {productId} to the warehouse {warehouseId}. Quantity - {quantity} {measurementUnits}\n");
    }

    public async Task ReportShipment(int warehouseId, int productId, int quantity, string measurementUnits)
    {
        Console.WriteLine($"\nReport: Shipping product {productId} from the warehouse {warehouseId}. Quantity - {quantity} {measurementUnits}\n");
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
```

### Fail Fast

Патерн Fail Fast використовується майже усюди, де потрібно перевірити умови перед виконанням певної дії.

```C#
public void RemoveItem(int productId, int quantity = 1)
{
    ThrowIfEditingAccepted();

    var Item = _items.FirstOrDefault(i => i.ProductId == productId);

    if (Item == null || Item.Quantity < quantity)
    {
        throw new ArgumentException($"Order does not have {quantity} products {productId}.");
    }

    Item.SetQuantity(Item.Quantity - quantity);

    RemoveEmptyItems();
}

public void ThrowIfEditingAccepted()
{
    if (Accepted)
        throw new ArgumentException("Cannot edit accepted order.");
}
```

Також було дотримано правила "постійно думати про unhappy path", а саме при написанні сервісів для складу та замовлення методи повертають ***Result***, який може містити або інформацію про помилку або тип даних, який повертає метод "обернутим" в результат. Завдяки  цьому користувачі сервісу можуть комфортно опрацювати обидва можливі happy and unhappy paths. Наприклад користувач сервісу ***ConsoleApp*** виводить у консоль помилку при її виникнені або виводить або повернене значенні або помилку в залежності від результату. 

```C#
public Result<Order> AcceptOrder(Order order, Warehouse warehouse)
{
    if (order.Accepted)
        return new ArgumentException("Cannot accept accepted order.");

    foreach(var item in order.Items)
    {
        if(!warehouse.Items.Any(i => i.ProductId == item.ProductId && i.Quantity >= item.Quantity))
            return new NotFoundException($"Not enough product {item.ProductId} in the warehouse {warehouse.Id}.");
    }

    foreach (var item in order.Items)
    {
        var res = _warehouseService.RemoveProduct(warehouse, item.ProductId, item.Quantity);

        if (res.IsFaulted) return res.IfSuccess(new Exception("Failed to remove product from warehouse"));
    }

    order.Accept();

    return order;
}
```


```C#
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
```

### SRP

Використовується патерн SRP, оскільки кожен клас відповідає за власний невеликий функціонал. Також щоб дотримуватися патерну було перенесено методи додавання/вінімання ціни (вказані у завданні) до класу ***Money*** з класу ***Product***.

### YAGNI

Було розроблено тільки потрібний функціонал, який стосується управління складом, замовленнями та звітністю та буде використано додатком.