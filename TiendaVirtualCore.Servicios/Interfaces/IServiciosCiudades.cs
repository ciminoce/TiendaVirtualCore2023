using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosCiudades
    {
        List<CiudadListDto> GetCiudades();
        void Guardar(Ciudad ciudad);
        void Borrar(int id);
        bool Existe(Ciudad ciudad);
        Ciudad GetCiudadPorId(int ciudadId);
        bool EstaRelacionado(Ciudad ciudad);
        int GetCantidad();

    }
}
