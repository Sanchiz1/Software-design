using Domain.Common.Exceptions;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WareHouseAggregate;
using Domain.Interfaces;
using Domain.ValueObjects;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;
public class OrderService : IOrderService
{
    private readonly IWarehouseService _warehouseService;

    public OrderService(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
    public Result<Order> AddProduct(Order order, Product Product, int quantity = 1)
    {
        if (order.Accepted)
            return new ArgumentException("Cannot edit accepted order.");

        if (!order.Items.Any(i => i.ProductId == Product.Id))
        {
            order.AddItem(new OrderItem(Product, quantity));

            return order;
        }

        var existingItem = order.Items.First(i => i.ProductId == Product.Id);

        existingItem.SetQuantity(existingItem.Quantity + quantity);

        return order;
    }

    public Result<Order> SetProductQuantity(Order order, int productId, int quantity = 1)
    {
        if (order.Accepted)
            return new ArgumentException("Cannot edit accepted order.");

        var item = order.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item == null)
            return new NotFoundException("No such product in the order.");

        if (item.Quantity < quantity)
            return new ArgumentException($"Only {item.Quantity} products in the order, trying to remove {quantity}.");

        item.SetQuantity(item.Quantity - quantity);

        order.RemoveEmptyItems();

        return order;
    }

    public Result<Order> AcceptOrder(Order order, Warehouse warehouse)
    {
        if (order.Accepted)
            return new ArgumentException("Cannot accept accepted order.");

        foreach(var item in order.Items)
        {
            if(!warehouse.Items.Any(i => i.ProductId == item.ProductId && i.Quantity >= item.Quantity))
                return new NotFoundException($"Not enough {item.ProductId} in the warehouse.");
        }

        foreach (var item in order.Items)
        {
            var res = _warehouseService.RemoveProduct(warehouse, item.ProductId, item.Quantity);

            if (res.IsFaulted) return res.Exception;
        }

        order.Accept();

        return order;
    }
}
