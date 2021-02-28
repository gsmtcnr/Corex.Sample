using Corex.Sample.Data.Infrastructure.Orders.Order;
using Corex.Sample.Model.EntityModel.Orders.Order;

namespace Corex.Sample.Operation.DataOperation.Orders.Order
{
    public class OrderDataOperation : CorexGuidDataOperation<OrderEntity,IOrderRepository>, IOrderDataOperation
    {

    }
}
