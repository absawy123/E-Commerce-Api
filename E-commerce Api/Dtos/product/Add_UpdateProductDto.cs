namespace E_commerce_Api.Dtos.product
{
    public class Add_UpdateProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}
