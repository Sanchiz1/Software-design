using Domain.Common.Exceptions;
using Domain.Entities.WareHouseAggregate;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IWarehouseService
{
    Result<Warehouse> AddProduct(Warehouse warehouse, int productId, string measurementUnits, int quantity = 1);

    Result<Warehouse> RemoveProduct(Warehouse warehouse, int productId, int quantity = 1);
}
