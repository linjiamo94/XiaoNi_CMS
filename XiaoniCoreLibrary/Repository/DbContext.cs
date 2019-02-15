using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XiaoniCoreLibrary.Models;

namespace XiaoniCoreLibrary.Repository
{
    public class StudentIdentityDbContext : IdentityDbContext<Student>
    {

        public StudentIdentityDbContext(DbContextOptions<StudentIdentityDbContext> option):base(option)
        {

        }
    }
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
    }
    public class LendingInfoDbContext : DbContext
    {
        public LendingInfoDbContext(DbContextOptions<LendingInfoDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetails> BooksDetail { get; set; }
        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<RecommendedBook> RecommendedBooks { get; set; }
    }
}
