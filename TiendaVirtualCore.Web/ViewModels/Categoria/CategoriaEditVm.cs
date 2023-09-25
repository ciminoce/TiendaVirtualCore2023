using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Categoria
{
    public class CategoriaEditVm
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(50,ErrorMessage ="Debe contener entre {2} y {1} caracteres",MinimumLength =3)]
        [Display(Name ="Categoría")]
        public string NombreCategoria { get; set; }

        [MaxLength(100, ErrorMessage = "No puede contener más de {1} caracteres")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        
        public byte[]? RowVersion { get; set; }
    }
}
