using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosCategorias
    {
        List<CategoriaListDto> GetCategorias();
        void Guardar(Categoria categoria);
        void Borrar(int id);
        bool Existe(Categoria categoria);
        Categoria GetCategoriaPorId(int categoriaId);
        bool EstaRelacionado(Categoria categoria);
        int GetCantidad();
    }
}
