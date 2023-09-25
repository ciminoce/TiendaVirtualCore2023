using AutoMapper;
using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Web.ViewModels.Categoria;
using TiendaVirtualCore.Web.ViewModels.Pais;

namespace TiendaVirtualCore.Web.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            LoadCategoriasMapping();
            LoadPaisesMapping();

        }

        private void LoadPaisesMapping()
        {
            CreateMap<PaisListDto, PaisListVm>();
            CreateMap<PaisEditVm, Pais>().ReverseMap();
        }

        private void LoadCategoriasMapping()
        {
            CreateMap<CategoriaListDto, CategoriaListVm>();
            CreateMap<CategoriaEditVm,Categoria>().ReverseMap();
        }
    }
}
