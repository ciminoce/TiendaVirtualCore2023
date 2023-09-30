using TiendaVirtualCore.Entities.Dtos.Cliente;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Interfaces
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetClientes();
        void Agregar(Cliente cliente);
        void Editar(Cliente cliente);
        void Borrar(int id);
        bool Existe(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad();
    }
}
