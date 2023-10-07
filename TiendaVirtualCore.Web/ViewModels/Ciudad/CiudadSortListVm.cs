namespace TiendaVirtualCore.Web.ViewModels.Ciudad
{
    public class CiudadSortListVm
    {
        public List<CiudadListVm> Ciudades { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }


    }
}
