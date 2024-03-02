using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetSevenCommerece.Models;

namespace NetSevenCommerece.DataAccess.Data
{
    public class ApplicationDBContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<TestCategory>().HasData(
               new TestCategory { Id = 1, Name = "TestAction", DisplayOrder = 1 },
               new TestCategory { Id = 2, Name = "TestScifi", DisplayOrder = 2 },
               new TestCategory { Id = 3, Name = "TestHistory", DisplayOrder = 3 }
               );
        }
    }
}
