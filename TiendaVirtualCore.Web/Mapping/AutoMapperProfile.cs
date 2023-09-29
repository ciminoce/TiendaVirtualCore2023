using AutoMapper;
using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Web.ViewModels.Categoria;
using TiendaVirtualCore.Web.ViewModels.Ciudad;
using TiendaVirtualCore.Web.ViewModels.Pais;

namespace TiendaVirtualCore.Web.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            LoadCategoriasMapping();
            LoadPaisesMapping();
            LoadCiudadesMapping();
        }

        private void LoadCiudadesMapping()
        {
            CreateMap<CiudadListDto, CiudadListVm>();
            CreateMap<CiudadEditVm, Ciudad>().ReverseMap();
            CreateMap<Ciudad, CiudadListVm>()
                .ForMember(dest => dest.NombrePais,
                opt => opt.MapFrom(src => src.Pais.NombrePais));
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
