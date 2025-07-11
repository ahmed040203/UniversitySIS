using Microsoft.EntityFrameworkCore;
using UniversitySIS.Domain.Entities;

namespace UniversitySIS.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
