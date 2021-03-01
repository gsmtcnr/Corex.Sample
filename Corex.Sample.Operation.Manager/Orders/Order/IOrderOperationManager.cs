using Corex.Sample.Model.DtoModel.Orders.Order;
using Corex.Sample.Model.EntityModel.Orders.Order;
using System;

namespace Corex.Sample.Operation.Manager.Orders.Order
{
    public interface IOrderOperationManager : ICorexOperationManager<Guid, OrderEntity, OrderDto>
    {
    }
}
