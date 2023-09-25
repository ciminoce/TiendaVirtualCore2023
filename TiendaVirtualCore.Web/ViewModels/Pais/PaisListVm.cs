using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Pais
{
    public class PaisListVm
    {
        public int PaisId { get; set; }

        [Display(Name = "País")]
        public string NombrePais { get; set; }


    }
}
