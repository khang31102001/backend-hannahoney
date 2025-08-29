using System;
using System.Security;

namespace backend_hannahoney.Models
{
	public class User
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string? EmailNormalized { get; set; } // upper-invariant để unique
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }

        // Mật khẩu & bảo mật
        public string? PasswordHash { get; set; }       // BCrypt/Argon2 hoặc Identity hasher
        public string? Provider { get; set; }
        public bool TwoFactorEnabled { get; set; } = false;

        // Trạng thái đăng nhập gần nhất
        public DateTimeOffset? LastLoginAt { get; set; }
        public string? LastLoginIp { get; set; }

        //relationship role

        public Guid RoleId { get; set; }
        public ICollection<Role>? Role { get; set; } = new List<Role>();

    }
}

