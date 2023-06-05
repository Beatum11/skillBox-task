using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfiAPI.Data.Models;

namespace ProfiAPI.Data.IF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet <Service> Services { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                                    : base(options) { }

    }
}
