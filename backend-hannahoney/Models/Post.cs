using System;
namespace backend_hannahoney.Models
{
	public class Post: SeoEntity
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string FeaturedImage { get; set; } = null!;
        public string? FeaturedImageAlt { get; set; }
        public string Content { get; set; } = null!;
        public string? ContentFormat { get; set; }
        public string Summary { get; set; } = null!;
        public string Status { get; set; } = null!; //Draft | Scheduled | Published | Archived

        // SEO
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? CanonicalUrl { get; set; }
        public string? MetaRobots { get; set; } = "index,follow";
        public string? OgTitle { get; set; }
        public string? OgDescription { get; set; }
        public string? OgImageUrl { get; set; }
        public string? TwitterCard { get; set; } = "summary_large_image";
        public string? TwitterSite { get; set; }
        public string? TwitterCreator { get; set; }
        public string? SchemaJsonLd { get; set; }
        public string? H1 { get; set; }
        public string? BreadcrumbTitle { get; set; }
        //relation category
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

