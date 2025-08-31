using System;
namespace backend_hannahoney.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Type { get; set; } = "product"; // "product" | "post"
        public int Level { get; set; }
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();
        public ICollection<Product>? Products { get; set;  } =  new List<Product>(); 
    }
}

