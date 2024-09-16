using ClinicaApp.Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Context
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clients { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consulta>()
             .ToTable("Consulta"); // Certi

            // Configurar a relação um-para-muitos
            modelBuilder.Entity<Consulta>()
            .HasOne(c => c.Cliente)
            .WithMany(cli => cli.Consultas)
            .HasForeignKey(c => c.ClienteId);

            //base.OnModelCreating(modelBuilder);
        }
    }
}

