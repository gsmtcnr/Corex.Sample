using Corex.Data.Infrastructure;
using Corex.Sample.Model.EntityModel.Products.Product;

namespace Corex.Sample.Data.Infrastructure.Products.Product
{
    public interface IProductRepository :
        ISelectableRepository<ProductEntity, int>,
        IUpdatableRepository<ProductEntity, int>,
        IDeletableRepository<ProductEntity, int>,
        IInsertableRepository<ProductEntity, int>
    {
    }
}
