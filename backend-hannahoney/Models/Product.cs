using System;
namespace backend_hannahoney.Models
{
    public class Product: BaseEntity
    {
       
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

        //relationship SEO
        public Guid? SEOId { get; set; }
        public SeoEntity? SEO { get; set; }

        // relationship category
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        

    }
}

