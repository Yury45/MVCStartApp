using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Models.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {       
            Database.EnsureCreated();
        }
    }
}
