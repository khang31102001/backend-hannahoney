using System;
namespace backend_hannahoney.Models
{
    public class Role: BaseEntity
    {
        
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;          // admin, editor, author...
        public string? Description { get; set; }
        public bool IsSystem { get; set; } = false;        // vai trò hệ thống không xoá
        
        public ICollection<User>? Users { get; set; } = new List<User>();
        
    }
}

