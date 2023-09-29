using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioCiudades
    {
        List<CiudadListDto> GetCiudades();
        void Agregar(Ciudad ciudad);
        void Editar(Ciudad ciudad);
        void Borrar(int id);
        bool Existe(Ciudad ciudad);
        Ciudad GetCiudadPorId(int ciudadId);
        bool EstaRelacionado(Ciudad ciudad);
        int GetCantidad();

    }
}
