using System.ComponentModel;

namespace TiendaVirtualCore.Web.ViewModels.Proveedor
{
    public class ProveedorListVm
    {
        public int ProveedorId { get; set; }
        [DisplayName("Proveedor")]
        public string NombreProveedor { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

    }
}
