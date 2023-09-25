using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualCore.Web.ViewModels.Categoria
{
    public class CategoriaListVm
    {
        public int CategoriaId { get; set; }

        [Display(Name ="Categoria")]
        public string NombreCategoria { get; set; }


    }
}
