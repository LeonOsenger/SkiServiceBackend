using Microsoft.EntityFrameworkCore;

namespace ProjektarbeitBackend.Models
{
    public class SkiServiceContext : DbContext
    {

        public DbSet<Mitarbeiter> mitarbeiters { get; set; }

        public DbSet<ServiceAuftrag> serviceAuftrag { get; set; }

        public DbSet<Dienstleistungen> serviceDienstleistungen { get; set; }
        public SkiServiceContext()
        {

        }

        public SkiServiceContext(DbContextOptions<SkiServiceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
