using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioPaises
    {
        List<PaisListDto> GetPaises();
        void Agregar(Pais pais);
        void Editar(Pais pais);
        void Borrar(int id);
        bool Existe(Pais pais);
        Pais GetPaisPorId(int paisId);
        bool EstaRelacionado(Pais pais);
        int GetCantidad();
    }
}
