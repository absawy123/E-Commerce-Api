using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public required string Description { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 
        [BindNever]
        public List<Product>? Products { get; set; }
    }
}
