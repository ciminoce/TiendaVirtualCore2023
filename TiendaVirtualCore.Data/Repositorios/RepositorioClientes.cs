using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Cliente;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly NeptunoDbContext _context;

        public RepositorioClientes(NeptunoDbContext context)
        {
            _context = context;
        }


        public void Agregar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);


        }

        public void Borrar(int id)
        {
            var clienteInDb =_context.Clientes
                .SingleOrDefault(p => p.Id == id);
            if (clienteInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(clienteInDb).State = EntityState.Deleted;


        }

        public void Editar(Cliente cliente)
        {
                var clienteInDb = _context.Clientes
                .SingleOrDefault(c => c.Id == cliente.Id);
                if (clienteInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                clienteInDb.Nombre = cliente.Nombre;
                clienteInDb.RowVersion = cliente.RowVersion;
                _context.Entry(clienteInDb).State = EntityState.Modified;


        }

        public bool EstaRelacionado(Cliente cliente)
        {
            return false;
        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                return _context.Clientes
                    .Any(p => p.Nombre == cliente.Nombre);
            }
            return _context.Clientes
                .Any(p => p.Nombre == cliente.Nombre && p.Id != cliente.Id);


        }

        public int GetCantidad()
        {
            return _context.Clientes.Count();
        }

        public List<ClienteListDto> GetClientes()
        {
            return _context.Clientes
                .OrderBy(c => c.Nombre)
                .Select(c => new ClienteListDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                })
                .ToList();

        }

        public Cliente GetClientePorId(int clienteId)
        {
            var clienteInDb =  _context.Clientes
                .SingleOrDefault(p => p.Id == clienteId);
            return clienteInDb;


        }

    }
}
