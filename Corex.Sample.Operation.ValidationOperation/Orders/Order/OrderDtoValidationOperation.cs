using Corex.Sample.Model.DtoModel.Orders.Order;
using Corex.Sample.Validation.DtoValidation.Orders.Order;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Sample.Operation.ValidationOperation.Orders.Order
{
    public class OrderDtoValidationOperation : CorexValidationOperation<OrderDto>, IOrderDtoValidationOperation
    {
        public override List<ValidationBase<OrderDto>> GetValidations()
        { 
            List<ValidationBase<OrderDto>> validationBases = new List<ValidationBase<OrderDto>>()
            {
                new OrderDtoRelationValidation(Item)
            };
            return validationBases;
        }
    }
}
