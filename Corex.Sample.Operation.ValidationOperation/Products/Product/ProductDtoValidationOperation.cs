using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Sample.Validation.DtoValidation.Products.Product;
using Corex.Validation.Infrastucture;
using System.Collections.Generic;

namespace Corex.Sample.Operation.ValidationOperation.Products.Product
{
    public class ProductDtoValidationOperation : CorexValidationOperation<ProductDto>, IProductDtoValidationOperation
    {
     
        public override List<ValidationBase<ProductDto>> GetValidations()
        {
            List<ValidationBase<ProductDto>> validationBases = new List<ValidationBase<ProductDto>>()
            {
                new ProductDtoNameValidation(Item),
                new ProductDtoPriceValidation(Item),
            };
            return validationBases;
        }
    }
}
