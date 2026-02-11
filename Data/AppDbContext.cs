using Microsoft.EntityFrameworkCore;
using SistemaCondominio.Api.Models;

namespace SistemaCondominio.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Morador> Moradores { get; set; }
        public DbSet<AreaComum> AreasComuns { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condominio>().ToTable("Condominios");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Apartamento>().ToTable("Apartamentos");
            modelBuilder.Entity<Morador>().ToTable("Moradores");
            modelBuilder.Entity<AreaComum>().ToTable("AreasComuns");
            modelBuilder.Entity<Reserva>().ToTable("Reservas");
            modelBuilder.Entity<Ocorrencia>().ToTable("Ocorrencias");

            base.OnModelCreating(modelBuilder);
        }
    }
}
