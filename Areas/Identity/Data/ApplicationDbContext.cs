using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DermaLogic.Models; 

namespace DermaLogic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        
        public DbSet<User> users { get; set; } 

        
        public DbSet<TestModule> TestModules { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        
    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}