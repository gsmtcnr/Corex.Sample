using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Sample.Model.EntityModel.Products.Product;

namespace Corex.Sample.Operation.Manager.Products.Product
{
    public interface IProductOperationManager : ICorexOperationManager<int, ProductEntity, ProductDto>
    {
    }
}
