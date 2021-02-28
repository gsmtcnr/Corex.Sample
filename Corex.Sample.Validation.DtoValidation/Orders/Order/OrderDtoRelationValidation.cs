using Corex.Sample.Model.DtoModel.Orders.Order;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Orders.Order
{
    public class OrderDtoRelationValidation : ValidationBase<OrderDto>
    {
        public OrderDtoRelationValidation(OrderDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            //Burada veri tabanı kontrolü değil sadece ilişkili kayıtların ID değerlerinin 0'dan büyük olma zorunluluğu kontrol edilir.
            ProductValidation();
            UserValidation();
        }
        private void ProductValidation()
        {
            RelationValidation(nameof(OrderDto.Product), Item.ProductId);
        }
        private void UserValidation()
        {
            RelationValidation(nameof(OrderDto.User), Item.UserId);
        }
    }
}
