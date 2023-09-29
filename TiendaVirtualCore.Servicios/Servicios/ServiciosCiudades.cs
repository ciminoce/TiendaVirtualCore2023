using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Entities.Dtos.Ciudad;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repitorioCiudades;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosCiudades(IRepositorioCiudades repitorioCiudades, IUnitOfWork unitOfWork)
        {
            _repitorioCiudades = repitorioCiudades;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int ciudadId)
        {
            try
            {
                _repitorioCiudades.Borrar(ciudadId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Ciudad ciudad)
        {
            try
            {
                return _repitorioCiudades.EstaRelacionado(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repitorioCiudades.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CiudadListDto> GetCiudades()
        {
            try
            {
                return _repitorioCiudades.GetCiudades();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ciudad GetCiudadPorId(int ciudadId)
        {
            try
            {
                return _repitorioCiudades.GetCiudadPorId(ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    _repitorioCiudades.Agregar(ciudad);

                }
                else
                {
                    _repitorioCiudades.Editar(ciudad);
                }
                _unitOfWork.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }


        public int GetCantidad()
        {
            try
            {
                return _repitorioCiudades.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            try
            {
                return _repitorioCiudades.EstaRelacionado(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
