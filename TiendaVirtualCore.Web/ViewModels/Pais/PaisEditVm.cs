using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Pais
{
    public class PaisEditVm
    {
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "Debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Categoría")]
        public string NombrePais { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
