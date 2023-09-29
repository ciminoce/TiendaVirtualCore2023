﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TiendaVirtualCore.Web.ViewModels.Ciudad
{
    public class CiudadEditVm
    {
        public int CiudadId { get; set; }

        [DisplayName("Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreCiudad { get; set; }

        [DisplayName("Pais")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un país")]
        public int PaisId { get; set; }
        public byte[]? RowVersion { get; set; }
        public List<SelectListItem>? Paises { get; set; }


    }
}
