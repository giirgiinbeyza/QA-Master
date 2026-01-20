using Microsoft.EntityFrameworkCore;

namespace DermaLogic.Models
{
    public class DermaLogicDbContext : DbContext
    {
        public DermaLogicDbContext(DbContextOptions<DermaLogicDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestModule> TestModules { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
    }
}