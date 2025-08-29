using System;
namespace backend_hannahoney.Models
{
    public class Product: BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Sku { get; set; }
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string FeaturedImage { get; set; } = null!;
        public string HoverImage { get; set; } = null!;
        public decimal? PriceOrigin { get; set; }
        public decimal PriceSale { get; set; }
        public decimal? PriceDiscount { get; set; } // giá gạch
        public string? Currency { get; set; } = "AUD";
        public int StockQuantity { get; set; }
        public bool TrackInventory { get; set; } = true;
        public double? WeightKg { get; set; }
        public string? UnitLabel { get; set; } // 150g/250g/500g

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

        // relationship category
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        

    }
}

