using Corex.Operation.Infrastructure;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.DtoModel.Orders.Order;
using Corex.Sample.Model.EntityModel.Orders.Order;
using Corex.Sample.Operation.DataOperation.Orders.Order;
using Corex.Sample.Operation.ValidationOperation.Orders.Order;
using System;

namespace Corex.Sample.Operation.Manager.Orders.Order
{
    public class OrderOperationManager : CorexGuidOperationManager<OrderEntity, OrderDto>, IOrderOperationManager
    {
        public override IDataOperation<OrderEntity, Guid> SetDataOperation()
        {
            return IoCManager.Resolve<IOrderDataOperation>();
        }

        public override IValidationOperation<OrderDto> SetInsertValidationOperation(OrderDto dto)
        {
            var validationOperation = IoCManager.Resolve<IOrderDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }

        public override IValidationOperation<OrderDto> SetUpdateValidationOperation(OrderDto dto)
        {
            var validationOperation = IoCManager.Resolve<IOrderDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
    }
}
