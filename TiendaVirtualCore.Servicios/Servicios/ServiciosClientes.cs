using TiendaVirtualCore.Data;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Cliente;
using TiendaVirtualCore.Entities.Models;
using TiendaVirtualCore.Servicios.Interfaces;

namespace TiendaVirtualCore.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repitorioClientes;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosClientes(IRepositorioClientes repitorioClientes, IUnitOfWork unitOfWork)
        {
            _repitorioClientes = repitorioClientes;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(int clienteId)
        {
            try
            {
                _repitorioClientes.Borrar(clienteId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Cliente cliente)
        {
            try
            {
                return _repitorioClientes.EstaRelacionado(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                return _repitorioClientes.Existe(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> GetClientes()
        {
            try
            {
                return _repitorioClientes.GetClientes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente GetClientePorId(int clienteId)
        {
            try
            {
                return _repitorioClientes.GetClientePorId(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.Id == 0)
                {
                    _repitorioClientes.Agregar(cliente);

                }
                else
                {
                    _repitorioClientes.Editar(cliente);
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
                return _repitorioClientes.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            try
            {
                return _repitorioClientes.EstaRelacionado(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
