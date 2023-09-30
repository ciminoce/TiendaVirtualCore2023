using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Data;
using TiendaVirtualCore.Entities.Dtos.Producto;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly IRepositorioProductos _repitorioProductos;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosProductos(IRepositorioProductos repitorioProductos, IUnitOfWork unitOfWork)
        {
            _repitorioProductos = repitorioProductos;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int productoId)
        {
            try
            {
                _repitorioProductos.Borrar(productoId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Producto producto)
        {
            try
            {
                return _repitorioProductos.EstaRelacionado(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                return _repitorioProductos.Existe(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductoListDto> GetProductos()
        {
            try
            {
                return _repitorioProductos.GetProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto GetProductoPorId(int productoId)
        {
            try
            {
                return _repitorioProductos.GetProductoPorId(productoId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                {
                    _repitorioProductos.Agregar(producto);

                }
                else
                {
                    _repitorioProductos.Editar(producto);
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
                return _repitorioProductos.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                return _repitorioProductos.EstaRelacionado(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
