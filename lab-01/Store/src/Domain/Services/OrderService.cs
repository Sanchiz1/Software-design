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

        if (order.IsDifferentCurrency(Product.Price.CurrencyCode))
            throw new ArgumentException("Cannot order products with prices in different currencies.");

        order.AddItem(Product, quantity);

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

        order.RemoveItem(productId, quantity);

        return order;
    }

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
}
