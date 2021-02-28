using Corex.Sample.Data.Infrastructure.Products.Product;
using Corex.Sample.Model.EntityModel.Products.Product;

namespace Corex.Sample.Operation.DataOperation.Products.Product
{
    public class ProductDataOperation : CorexIntDataOperation<ProductEntity, IProductRepository>, IProductDataOperation
    {
    }
}
