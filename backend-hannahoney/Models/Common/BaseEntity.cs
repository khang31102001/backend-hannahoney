using System;
namespace backend_hannahoney.Models
{
	public class BaseEntity
	{
    
        // Audit
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        // Soft delete
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        // Enable/Disable (hiển thị/bán hay không)
        public bool IsActive { get; set; } = true;
        public DateTimeOffset? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }
    }
}

