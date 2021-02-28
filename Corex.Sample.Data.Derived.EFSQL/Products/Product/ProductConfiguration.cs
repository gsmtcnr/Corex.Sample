using Corex.Sample.Model.EntityModel.Products.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corex.Sample.Data.Derived.EFSQL.Products.Product
{
    public class ProductConfiguration : CorexBaseEntityIntConfiguration<ProductEntity>
    {
        public override string GetSchemaName()
        {
            return "Product";
        }
        public override string GetTableName()
        {
            return "Product";
        }
        public override void Map(EntityTypeBuilder<ProductEntity> entity)
        {
            entity.Property(m => m.Name).HasMaxLength(32).IsRequired();
            entity.Property(m => m.Price).IsRequired();
            base.Map(entity);
        }
    }
}
