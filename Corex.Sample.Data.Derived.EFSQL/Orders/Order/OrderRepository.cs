using Corex.Sample.Data.Infrastructure.Orders.Order;
using Corex.Sample.Model.EntityModel.Orders.Order;

namespace Corex.Sample.Data.Derived.EFSQL.Orders.Order
{
    public class OrderRepository : CorexBaseEntityGuidRepository<OrderEntity>, IOrderRepository
    {
    }
}
