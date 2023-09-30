using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.EntityTypeConfigurations
{
    public class ProveedorMap : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
