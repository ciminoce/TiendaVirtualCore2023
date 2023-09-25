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
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(NeptunoDbContext)));
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaMap());
            modelBuilder.ApplyConfiguration<Pais>(new PaisMap());
            //modelBuilder.Entity<Categoria>().ToTable("Categorias");
            //modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaId);
            //modelBuilder.Entity<Categoria>().Property(c => c.RowVersion).IsRowVersion();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pais> Paises { get; set; }
    }
}
