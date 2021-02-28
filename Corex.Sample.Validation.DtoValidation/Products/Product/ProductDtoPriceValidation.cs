using Corex.Sample.Model.DtoModel.Products.Product;
using Corex.Validation.Infrastucture;

namespace Corex.Sample.Validation.DtoValidation.Products.Product
{
    public class ProductDtoPriceValidation : ValidationBase<ProductDto>
    {
        public ProductDtoPriceValidation(ProductDto item) : base(item)
        {
        }

        protected override void Validate()
        {
            MinValueValidation();
        }
        private void MinValueValidation()
        {
            MinValueValidation(nameof(ProductDto.Price), Item.Price, 0);
        }
 
    }
}
