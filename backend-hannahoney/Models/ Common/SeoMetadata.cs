using System;
namespace backend_hannahoney.Models.Common
{
    public class SeoMetadata
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // === Meta cơ bản ===
        public string? Title { get; set; }           // ~50–60 ký tự, tiêu đề SEO
        public string? MetaDescription { get; set; } // ~120–160 ký tự, mô tả meta
        public string? CanonicalUrl { get; set; }    // URL chính, tránh duplicate content
        public string? Slug { get; set; }            // đường dẫn thân thiện, vd: jarrah-ta35-500g

        // === Open Graph (Facebook, LinkedIn, Zalo...) ===
        public string? OgTitle { get; set; }         // nếu khác với Title
        public string? OgDescription { get; set; }
        public string? OgImageUrl { get; set; }      // ảnh preview khi share

        // === Twitter Card ===
        public string? TwitterCard { get; set; } = "summary_large_image";
        public string? TwitterTitle { get; set; }
        public string? TwitterDescription { get; set; }
        public string? TwitterImageUrl { get; set; }

        // === Robots & Indexing ===
        public string Robots { get; set; } = "index,follow"; // noindex,nofollow nếu muốn chặn

        // === Thời gian tạo & cập nhật ===
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
    }
}

