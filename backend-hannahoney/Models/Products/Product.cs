using System;
using backend_hannahoney.Models.Products;

namespace backend_hannahoney.Models
{
    public sealed class Product : BaseEntity
	{
        public string? Name { get; set; }
        public string? ImageFeature { set; get; }
        public string? Sku { get; set; } // ma sp
        public string? Slug { get; set; } //seo
        public string? Summary { get; set; }                  
        public string? DescriptionHtml { get; set; }          
        public decimal? PriceOrigin { get; set; }
        public decimal? PriceSale { get; set; }
        public decimal? PriceDiscount { get; set; }
        public string? Currency { get; set; } = "VN";

        public ICollection<ProductMedia> Gallery { get; set; } = new List<ProductMedia>();


    }
}

