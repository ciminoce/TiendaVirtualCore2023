using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosPaises
    {
        List<PaisListDto> GetPaises();
        void Guardar(Pais pais);
        void Borrar(int id);
        bool Existe(Pais pais);
        Pais GetPaisPorId(int paisId);
        bool EstaRelacionado(Pais pais);
        int GetCantidad();
        List<SelectListItem> GetPaisesDropDown();
    }
}
