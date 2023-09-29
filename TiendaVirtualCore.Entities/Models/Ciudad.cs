namespace TiendaVirtualCore.Entities.Models
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public int PaisId { get; set; }
        public byte[] RowVersion { get; set; }

        public Pais Pais { get; set; }
    }
}
