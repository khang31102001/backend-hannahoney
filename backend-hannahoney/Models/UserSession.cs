using System;
namespace backend_hannahoney.Models
{
	public class UserSession
	{
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public string RefreshTokenHash { get; set; } = null!; // luôn lưu dạng hash
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset? RevokedAt { get; set; }
        public string? ReplacedByTokenHash { get; set; }      // chuỗi thay thế token (rotation)

        // Thông tin thiết bị/nguồn
        public string? Device { get; set; }                   // "iPhone 15", "MacBook", ...
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }

        public bool IsActiveSession => RevokedAt == null && ExpiresAt > DateTimeOffset.UtcNow;
    }
}

