using TiendaVirtualCore.Entities.Dtos.Cliente;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        List<ClienteListDto> GetClientes();
        void Guardar(Cliente cliente);
        void Borrar(int id);
        bool Existe(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad();

    }
}
