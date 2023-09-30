using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.EntityTypeConfigurations
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(p => p.ProductoId);
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
