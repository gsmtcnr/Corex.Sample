using Corex.Operation.Infrastructure;
using Corex.Sample.Core.Infrastructure;
using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Sample.Model.EntityModel.Products.Product;
using Corex.Sample.Operation.DataOperation.Products.Product;
using Corex.Sample.Operation.ValidationOperation.Products.Product;

namespace Corex.Sample.Operation.Manager.Products.Product
{
    public class ProductOperationManager : CorexIntOperationManager<ProductEntity, ProductDto>, IProductOperationManager
    {
        public override IDataOperation<ProductEntity, int> SetDataOperation()
        {
            return IoCManager.Resolve<IProductDataOperation>();
        }
        public override IValidationOperation<ProductDto> SetInsertValidationOperation(ProductDto dto)
        {
            var validationOperation = IoCManager.Resolve<IProductDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }

        public override IValidationOperation<ProductDto> SetUpdateValidationOperation(ProductDto dto)
        {
            var validationOperation = IoCManager.Resolve<IProductDtoValidationOperation>();
            validationOperation.SetItem(dto);
            return validationOperation;
        }
    }
}
