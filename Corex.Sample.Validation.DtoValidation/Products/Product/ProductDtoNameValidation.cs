using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Products.Product
{
    public class ProductDtoNameValidation : ValidationBase<ProductDto>
    {
        public ProductDtoNameValidation(ProductDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            RequiredValidation();
            LimitValidation();
        }
        private void RequiredValidation()
        {
            StringRequiredValidation(nameof(ProductDto.Name), Item.Name);
        }
        private void LimitValidation()
        {
            StringLimitValidation(nameof(ProductDto.Name), Item.Name, 32);
        }
    }
}
