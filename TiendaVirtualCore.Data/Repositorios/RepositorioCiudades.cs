using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {
        private readonly NeptunoDbContext _context;

        public RepositorioCiudades(NeptunoDbContext context)
        {
            _context = context;
        }

        public void Agregar(Ciudad ciudad)
        {
            try
            {
                _context.Ciudades.Add(ciudad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Borrar(int ciudadId)
        {
            try
            {
                var ciudadInDb = GetCiudadPorId(ciudadId);
                if (ciudadInDb == null)
                {
                    throw new Exception("Registro dado de baja por otro usuario");
                }
                else
                {
                    //ciudadInDb.Pais = null;
                    _context.Entry(ciudadInDb).State = EntityState.Deleted;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Editar(Ciudad ciudad)
        {
            try
            {
                var ciudadInDb = GetCiudadPorId(ciudad.CiudadId);

                if (ciudadInDb == null)
                {
                    throw new Exception("Registro dado de baja por otro usuario");
                }
                ciudadInDb.Pais = null;
                ciudadInDb.NombreCiudad = ciudad.NombreCiudad;
                ciudadInDb.PaisId = ciudad.PaisId;
                ciudadInDb.RowVersion = ciudad.RowVersion;

                _context.Entry(ciudadInDb).State = EntityState.Modified;
                //_context.Entry(ciudad).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool EstaRelacionado(Ciudad ciudad)
        {
            return false;
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    return _context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad
                        && c.PaisId == ciudad.PaisId);

                }
                return _context.Ciudades.Any(c => c.NombreCiudad == ciudad.NombreCiudad
                            && c.PaisId == ciudad.PaisId
                            && c.CiudadId != ciudad.CiudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int GetCantidad()
        {
            return _context.Ciudades.Count();
        }


        public List<CiudadListDto> GetCiudades()
        {
            return _context.Ciudades.Include(c => c.Pais)
                .Select(c => new CiudadListDto
                {
                    CiudadId = c.CiudadId,
                    NombreCiudad = c.NombreCiudad,
                    NombrePais = c.Pais.NombrePais
                }).AsNoTracking()
                .ToList();
        }




        public Ciudad GetCiudadPorId(int ciudadId)
        {
            try
            {
                return _context.Ciudades.Include(c => c.Pais)
                    .AsNoTracking()
                    .SingleOrDefault(c => c.CiudadId == ciudadId);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
