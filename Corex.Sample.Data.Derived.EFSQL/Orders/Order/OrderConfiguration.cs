using Corex.Sample.Model.EntityModel.Orders.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corex.Sample.Data.Derived.EFSQL.Orders.Order
{
    public class OrderConfiguration : CorexBaseEntityGuidConfiguration<OrderEntity>
    {
        public override string GetSchemaName()
        {
            return "Order";
        }
        public override string GetTableName()
        {
            return "Order";
        }
        public override void Map(EntityTypeBuilder<OrderEntity> entity)
        {
            entity.HasOne(m => m.User).WithMany().IsRequired().HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(m => m.Product).WithMany().IsRequired().HasForeignKey(m => m.ProductId).OnDelete(DeleteBehavior.Restrict);
            base.Map(entity);
        }
    }
}
