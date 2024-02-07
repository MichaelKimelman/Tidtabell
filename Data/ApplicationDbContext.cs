using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tidtabell.Models;

namespace Tidtabell.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tidtabell.Models.Line> Line { get; set; } = default!;
        public DbSet<Tidtabell.Models.Stop> Stop { get; set; } = default!;
        public DbSet<Tidtabell.Models.Time> Time { get; set; } = default!;
    }
}