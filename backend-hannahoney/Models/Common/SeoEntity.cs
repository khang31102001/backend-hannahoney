using System;
namespace backend_hannahoney.Models
{
    public class SeoEntity
    {
        public  Guid Id { get; set; } = Guid.NewGuid();
        // Core content
        public string Title { get; set; } = null!;
        public string? Excerpt { get; set; }
        public string? Content { get; set; }

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

        // Publish & audit
        //public bool IsPublished { get; set; }
        //public DateTimeOffset? PublishedAt { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        //public DateTimeOffset? UpdatedAt { get; set; }
        //public string? CreatedBy { get; set; }
        //public string? UpdatedBy { get; set; }
    }

   

}

