﻿using System;
namespace backend_hannahoney.Models
{
	public abstract class BaseEntity
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

