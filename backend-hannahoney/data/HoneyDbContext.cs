
using System;
using backend_hannahoney.Models;
using Microsoft.EntityFrameworkCore;
namespace backend_hannahoney.data
{
    public class HoneyDbContext : DbContext
    {
        public HoneyDbContext(DbContextOptions<HoneyDbContext> options) : base(options) { }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserSession> UserSession { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Users
            modelBuilder.Entity<User>(entity =>
            {
                // Đặt tên bảng là 'Users'
                entity.ToTable("Users");

                // Cấu hình khóa chính
                entity.HasKey(e => e.Id);

                // Cấu hình thuộc tính 'Email'
                entity.Property(e => e.Email)
                      .IsRequired() // Bắt buộc
                      .HasMaxLength(256); // Độ dài tối đa

                // Cấu hình thuộc tính 'EmailNormalized' với chỉ mục duy nhất
                entity.Property(e => e.EmailNormalized)
                      .IsRequired()
                      .HasMaxLength(256);
                entity.HasIndex(e => e.EmailNormalized)
                      .IsUnique();

                // Cấu hình thuộc tính 'FullName'
                entity.Property(e => e.FullName)
                      .HasMaxLength(256);

                // Cấu hình thuộc tính 'AvatarUrl'
                entity.Property(e => e.AvatarUrl)
                      .HasMaxLength(512);

                // Cấu hình thuộc tính 'PasswordHash'
                entity.Property(e => e.PasswordHash)
                      .HasMaxLength(256);

                // Cấu hình mối quan hệ Một-nhiều
                // Một Role có thể có nhiều User
                entity.HasOne<Role>()
                      .WithMany(r => r.Users) // Giả định Role có thuộc tính ICollection<User> Users
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Cascade); // Xóa người dùng khi vai trò bị xóa
            });

            // Cấu hình bảng Roles 
            modelBuilder.Entity<Role>(entity =>
            {
                // Đặt tên bảng là "Roles"
                entity.ToTable("Roles");

                // Cấu hình khóa chính
                entity.HasKey(r => r.Id);

                // Cấu hình thuộc tính 'Id' thành CHAR(36)
                entity.Property(r => r.Id)
                    .HasColumnType("char(36)");

                // Cấu hình 'Name'
                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                // Cấu hình 'Slug' với chỉ mục duy nhất
                entity.Property(r => r.Slug)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasIndex(r => r.Slug)
                    .IsUnique();

                // Cấu hình 'Description'
                entity.Property(r => r.Description)
                    .HasColumnType("text");

                // Cấu hình 'IsSystem'
                entity.Property(r => r.IsSystem)
                    .IsRequired();

                // Cấu hình mối quan hệ One-to-Many với bảng User
                // Một Role có thể có nhiều User
                entity.HasMany(r => r.Users)
                    .WithOne()
                    .HasForeignKey(u => u.RoleId) // Giả định User có thuộc tính RoleId
                    .OnDelete(DeleteBehavior.Restrict); // Không cho phép xóa Role nếu còn User liên kết
            });
            // Cấu hình bảng User Session 
            modelBuilder.Entity<UserSession>(entity =>
            {
                // Đặt tên bảng là 'UserSessions'
                entity.ToTable("UserSessions");

                // Cấu hình khóa chính tổng hợp (Composite Primary Key)
                // Một cặp UserId và RefreshTokenHash sẽ là duy nhất
                entity.HasKey(us => us.Id);

                // Cấu hình khóa ngoại (Foreign Key)
                // Một phiên UserSession chỉ thuộc về một User duy nhất
                entity.HasOne(us => us.User)
                    .WithMany() // Mối quan hệ một-nhiều (một User có nhiều UserSession)
                    .HasForeignKey(us => us.UserId);

                // Cấu hình các thuộc tính
                entity.Property(us => us.RefreshTokenHash)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.HasIndex(us => us.RefreshTokenHash).IsUnique();

                entity.Property(us => us.ReplacedByTokenHash)
                    .HasMaxLength(256);

                entity.Property(us => us.Device)
                    .HasMaxLength(256);

                entity.Property(us => us.UserAgent)
                    .HasMaxLength(512);

                entity.Property(us => us.IpAddress)
                    .HasMaxLength(45); // IP v4 (15 ký tự) hoặc IP v6 (45 ký tự)

            });

            // Cấu hình bảng Products
            modelBuilder.Entity<Product>(entity =>
            {
                // Đặt tên bảng là 'Products'
                entity.ToTable("Products");

                // Cấu hình Khóa chính. Lưu ý: Id được kế thừa từ BaseEntity
                entity.HasKey(p => p.Id);

                // Cấu hình các thuộc tính
                entity.Property(p => p.Sku)
                    .HasMaxLength(50); // Giới hạn độ dài SKU



                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(255); // Bắt buộc và giới hạn độ dài

                entity.Property(p => p.Slug)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasIndex(p => p.Slug)
                    .IsUnique(); // Đảm bảo Slug là duy nhất

                entity.Property(p => p.Description)
                    .HasColumnType("text"); // Kiểu dữ liệu văn bản dài

                entity.Property(p => p.FeaturedImage)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(p => p.HoverImage)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(p => p.PriceOrigin)
                    .HasPrecision(18, 2); // Kiểu dữ liệu decimal(18, 2)

                entity.Property(p => p.PriceSale)
                    .IsRequired()
                    .HasPrecision(18, 2);

                entity.Property(p => p.PriceDiscount)
                    .HasPrecision(18, 2);

                entity.Property(p => p.Currency)
                    .HasMaxLength(10);

                // Cấu hình các thuộc tính audit, soft delete từ BaseEntity
                entity.Property(p => p.CreatedAt).IsRequired();
                entity.Property(p => p.IsDeleted).IsRequired();
                entity.Property(p => p.IsActive).IsRequired();

                // Cấu hình mối quan hệ One-to-One với SeoEntity
                entity.HasOne(p => p.SEO)
                    .WithOne()
                    .HasForeignKey<Product>(p => p.SEOId);

                // Cấu hình mối quan hệ Many-to-One với Category
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products) // Giả định Category có ICollection<Product> Products
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired(false); // Cho phép Product không thuộc Category nào

            });

            // Cấu hình bảng Posts
            modelBuilder.Entity<Post>(entity =>
            {
                // Chỉ định tên bảng trong cơ sở dữ liệu
                entity.ToTable("Posts");

                // Cấu hình thuộc tính
                entity.Property(p => p.Title)
                    .IsRequired() // Bắt buộc
                    .HasMaxLength(255); // Độ dài tối đa 255 ký tự

                entity.Property(p => p.Slug)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.HasIndex(p => p.Slug)
                    .IsUnique();

                entity.Property(p => p.FeaturedImage)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(p => p.FeaturedImageAlt)
                    .HasMaxLength(500); // Tùy chọn

                entity.Property(p => p.Content)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)"); // Sử dụng nvarchar(max) cho nội dung lớn

                entity.Property(p => p.Summary)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(p => p.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                

                // Cấu hình mối quan hệ
                // Mối quan hệ với SeoEntity (1 Post có 1 SEO, SEO có thể null)
                entity.HasOne(p => p.SEO)
                    .WithMany()
                    .HasForeignKey(p => p.SEOId)
                    .IsRequired(false); // Quan hệ tùy chọn

                // Mối quan hệ với Category (1 Post có 1 Category, Category có thể null)
                entity.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired(false); // Quan hệ tùy chọn



            });
            
             // Cấu hình cho bảng Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                // Cấu hình các thuộc tính
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(c => c.Slug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(c => c.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("product");

                entity.Property(c => c.Level).IsRequired();

                // Cấu hình mối quan hệ tự tham chiếu (self-referencing)
                // Một Category có một Parent và nhiều Children
                entity.HasOne(c => c.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(c => c.ParentId)
                    .IsRequired(false) // ParentId có thể null
                    .OnDelete(DeleteBehavior.Restrict); // Ngăn không cho xóa một category cha nếu nó có category con

                // Cấu hình mối quan hệ với Product
                // Một Category có nhiều Products (Giả định Product có khóa ngoại CategoryId)
                entity.HasMany(c => c.Products)
                    .WithOne()
                    .HasForeignKey("CategoryId") // Sử dụng tên khóa ngoại mặc định
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                // Thêm index duy nhất cho trường Slug
                entity.HasIndex(c => c.Slug)
                    .IsUnique();
            });
            
            

        }

    }
}