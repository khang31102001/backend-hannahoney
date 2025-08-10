using System;
namespace backend_hannahoney.Models.Common
{
    public enum SchemaType
    {
        Product, BlogPosting, Organization, WebSite, WebPage, BreadcrumbList, FAQPage
    }

    public class SchemaSnippet
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Type { get; set; }    // Loại schema
        public Guid? EntityId { get; set; }     // Id của Product, Blog... nếu liên quan

        public string? JsonLd { get; set; }      // Nội dung JSON-LD (string)
        public bool IsActive { get; set; } = true;

        // Nếu true → dùng bản thủ công này thay vì generate tự động
        public bool IsManualOverride { get; set; } = false;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
    }
}

