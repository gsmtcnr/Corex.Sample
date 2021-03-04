using Corex.Sample.Data.Infrastructure.Products.Product;
using Corex.Sample.Model.EntityModel.Products.Product;

namespace Corex.Sample.Data.Derived.EFSQL.Products.Product
{
    public class ProductRepository : CorexBaseEntityIntRepository<ProductEntity>, IProductRepository
    {
    }
}
