using Corex.Sample.Model.EntityModel.Products.Product;
using Corex.Sample.Model.EntityModel.Users.User;

namespace Corex.Sample.Model.EntityModel.Orders.Order
{
    public class OrderEntity : BaseCorexEntityGuidModel
    {
        public UserEntity User { get; set; }
        public int UserId { get; set; }
        public ProductEntity Product { get; set; }
        public int ProductId { get; set; }
    }
}
