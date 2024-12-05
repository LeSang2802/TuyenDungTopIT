using Microsoft.EntityFrameworkCore;
using TuyenDungTopIT.Models;

namespace TuyenDungTopIT.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Jobs> Jobs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Cấu hình thêm nếu cần thiết
        //    modelBuilder.Entity<Jobs>()
        //        .Property(j => j.PostedAt)
        //        .HasDefaultValueSql("GETDATE()"); // Giá trị mặc định cho PostedAt
        //}
    }
}
