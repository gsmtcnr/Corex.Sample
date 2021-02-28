using Corex.Data.Infrastructure;
using Corex.Sample.Model.EntityModel.Orders.Order;
using System;

namespace Corex.Sample.Data.Infrastructure.Orders.Order
{
    public interface IOrderRepository :
        ISelectableRepository<OrderEntity, Guid>,
        IUpdatableRepository<OrderEntity, Guid>,
        IInsertableRepository<OrderEntity, Guid>
    {
    }
}
