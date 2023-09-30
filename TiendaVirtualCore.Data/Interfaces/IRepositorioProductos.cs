using TiendaVirtualCore.Entities.Dtos.Producto;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioProductos
    {
        List<ProductoListDto> GetProductos();
        void Agregar(Producto producto);
        void Editar(Producto producto);
        void Borrar(int id);
        bool Existe(Producto producto);
        Producto GetProductoPorId(int productoId);
        bool EstaRelacionado(Producto producto);
        int GetCantidad();
    }
}
