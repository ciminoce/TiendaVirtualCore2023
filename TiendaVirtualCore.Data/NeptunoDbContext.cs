using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TiendaVirtualCore.Data.EntityTypeConfigurations;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data
{
    public class NeptunoDbContext : DbContext
    {
        public NeptunoDbContext(DbContextOptions<NeptunoDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaMap());
            modelBuilder.ApplyConfiguration<Pais>(new PaisMap());
            modelBuilder.ApplyConfiguration<Ciudad>(new CiudadMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
