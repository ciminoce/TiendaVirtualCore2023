using System.ComponentModel;

namespace TiendaVirtualCore.Web.ViewModels.Cliente
{
    public class ClienteListVm
    {
        public int ClienteId { get; set; }
        [DisplayName("Proveedor")]
        public string NombreCliente { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }


    }
}
