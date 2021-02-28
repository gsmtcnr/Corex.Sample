using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Sample.Model.DtoModel.Users.User;

namespace Corex.Sample.Model.DtoModel.Orders.Order
{
    public class OrderDto : BaseCorexDtoGuidModel
    {
        public OrderDto()
        {

        }
        public OrderDto(int userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
        public UserDto User { get; set; }
        public int UserId { get; set; }

        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
    }
}
