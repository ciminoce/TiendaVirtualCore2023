using TiendaVirtualCore.Entities.Dtos.Proveedor;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioProveedores
    {
        List<ProveedorListDto> GetProveedores();
        void Agregar(Proveedor proveedor);
        void Editar(Proveedor proveedor);
        void Borrar(int id);
        bool Existe(Proveedor proveedor);
        Proveedor GetProveedorPorId(int proveedorId);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad();
    }
}
