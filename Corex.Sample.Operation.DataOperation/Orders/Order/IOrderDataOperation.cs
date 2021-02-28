using Corex.Operation.Infrastructure;
using Corex.Sample.Model.EntityModel.Orders.Order;
using System;

namespace Corex.Sample.Operation.DataOperation.Orders.Order
{
    public interface IOrderDataOperation : IDataOperation<OrderEntity, Guid>
    {
    }
}
