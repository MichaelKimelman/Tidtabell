using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tidtabell.Models;
using Tidtabell.Models.Join_Tables;

namespace Tidtabell.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();
        public DbSet<Tidtabell.Models.Line> Line { get; set; } = default!;
        public DbSet<Tidtabell.Models.Stop> Stop { get; set; } = default!;
        public DbSet<Tidtabell.Models.Time> Time { get; set; } = default!;
        public DbSet<Tidtabell.Models.Join_Tables.LineStops> LineStops { get; set; } = default!;
        public DbSet<Tidtabell.Models.Join_Tables.LineTimes> LineTimes { get; set; } = default!;
        public DbSet<Tidtabell.Models.Join_Tables.StopTimes> StopTimes { get; set; } = default!;
    }
}