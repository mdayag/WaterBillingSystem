using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
   
        }

        public DbSet<Barangay> Barangays { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Book>()
            //    .HasOne(b => b.Borrower)
            //    .WithMany()
            //    .HasForeignKey(a => a.BorrowerId);

            // EF Core 2.1 doesnt support Cascade on delete for in Memory Database

            base.OnModelCreating(builder);
        }
    }
}
