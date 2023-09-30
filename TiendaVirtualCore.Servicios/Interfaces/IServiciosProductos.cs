using TiendaVirtualCore.Entities.Dtos.Producto;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosProductos
    {
        List<ProductoListDto> GetProductos();
        void Guardar(Producto producto);
        void Borrar(int id);
        bool Existe(Producto producto);
        Producto GetProductoPorId(int productoId);
        bool EstaRelacionado(Producto producto);
        int GetCantidad();

    }
}
