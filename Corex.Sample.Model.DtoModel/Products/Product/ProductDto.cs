namespace Corex.Sample.Model.DtoModel.Products.Product
{
    public class ProductDto : BaseCorexDtoIntModel
    {
        public ProductDto()
        {

        }
        public ProductDto(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
