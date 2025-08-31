using System;
namespace backend_hannahoney.Models
{
	public class Post: BaseEntity
	{
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string FeaturedImage { get; set; } = null!;
        public string? FeaturedImageAlt { get; set; }
        public string Content { get; set; } = null!;
        public string? ContentFormat { get; set; }
        public string Summary { get; set; } = null!;
        public string Status { get; set; } = null!; //Draft | Scheduled | Published | Archived

        //relationship SEO
        public Guid? SEOId { get; set; }
        public SeoEntity? SEO { get; set; }
        //relation category
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

