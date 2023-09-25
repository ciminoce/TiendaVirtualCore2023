using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioCategorias
    {
        List<CategoriaListDto> GetCategorias();
        void Agregar(Categoria categoria);
        void Editar(Categoria categoria);
        void Borrar(int id);
        bool Existe(Categoria categoria);
        Categoria GetCategoriaPorId(int categoriaId);
        bool EstaRelacionado(Categoria categoria);
        int GetCantidad();
    }
}
