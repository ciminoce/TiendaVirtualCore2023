using System.ComponentModel;

namespace TiendaVirtualCore.Web.ViewModels.Ciudad
{
    public class CiudadListVm
    {
        public int CiudadId { get; set; }
        [DisplayName("Ciudad")]
        public string NombreCiudad { get; set; }
        [DisplayName("País")]
        public string NombrePais { get; set; }


    }
}
