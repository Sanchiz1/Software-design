using Domain.Common.Exceptions;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WareHouseAggregate;
using Domain.Services;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IOrderService
{
    Result<Order> AddProduct(Order order, Product Product, int quantity = 1);

    Result<Order> SetProductQuantity(Order order, int productId, int quantity = 1);

    Result<Order> AcceptOrder(Order order, Warehouse warehouse);
}
