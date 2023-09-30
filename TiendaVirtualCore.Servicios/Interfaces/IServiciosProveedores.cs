using TiendaVirtualCore.Entities.Dtos.Proveedor;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosProveedores
    {
        List<ProveedorListDto> GetProveedores();
        void Guardar(Proveedor proveedor);
        void Borrar(int id);
        bool Existe(Proveedor proveedor);
        Proveedor GetProveedorPorId(int proveedorId);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad();

    }
}
