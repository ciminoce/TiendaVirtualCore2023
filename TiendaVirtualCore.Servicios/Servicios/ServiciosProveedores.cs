using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Entities.Dtos.Proveedor;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosProveedores : IServiciosProveedores
    {
        private readonly IRepositorioProveedores _repitorioProveedores;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosProveedores(IRepositorioProveedores repitorioProveedores, IUnitOfWork unitOfWork)
        {
            _repitorioProveedores = repitorioProveedores;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int proveedorId)
        {
            try
            {
                _repitorioProveedores.Borrar(proveedorId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Proveedor proveedor)
        {
            try
            {
                return _repitorioProveedores.EstaRelacionado(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return _repitorioProveedores.Existe(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProveedorListDto> GetProveedores()
        {
            try
            {
                return _repitorioProveedores.GetProveedores();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Proveedor GetProveedorPorId(int proveedorId)
        {
            try
            {
                return _repitorioProveedores.GetProveedorPorId(proveedorId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.Id == 0)
                {
                    _repitorioProveedores.Agregar(proveedor);

                }
                else
                {
                    _repitorioProveedores.Editar(proveedor);
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
                return _repitorioProveedores.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                return _repitorioProveedores.EstaRelacionado(proveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
