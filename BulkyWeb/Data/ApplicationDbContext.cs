using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext:DbContext // implement DbContext class
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            // create a constructor and  connection string is injected inside
            // BASE(OPTION): Đây là cú pháp gọi constructor của lớp cha (trong trường hợp này là DbContext) và truyền options vào lớp cha.
        }
        // create a table       // name of table
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Fiction", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "History", DisplayOrder = 3 }
            ); 
        }
    }
}
