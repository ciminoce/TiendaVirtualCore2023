using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Proveedor;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly NeptunoDbContext _context;

        public RepositorioProveedores(NeptunoDbContext context)
        {
            _context = context;
        }


        public void Agregar(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);


        }

        public void Borrar(int id)
        {
            var proveedorInDb =_context.Proveedores
                .SingleOrDefault(p => p.Id == id);
            if (proveedorInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(proveedorInDb).State = EntityState.Deleted;


        }

        public void Editar(Proveedor proveedor)
        {
                var proveedorInDb = _context.Proveedores
                .SingleOrDefault(c => c.Id == proveedor.Id);
                if (proveedorInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                proveedorInDb.Nombre = proveedor.Nombre;
                proveedorInDb.RowVersion = proveedor.RowVersion;
                _context.Entry(proveedorInDb).State = EntityState.Modified;


        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            return false;
        }

        public bool Existe(Proveedor proveedor)
        {
            if (proveedor.Id == 0)
            {
                return _context.Proveedores
                    .Any(p => p.Nombre == proveedor.Nombre);
            }
            return _context.Proveedores
                .Any(p => p.Nombre == proveedor.Nombre && p.Id != proveedor.Id);


        }

        public int GetCantidad()
        {
            return _context.Proveedores.Count();
        }

        public List<ProveedorListDto> GetProveedores()
        {
            return _context.Proveedores
                .OrderBy(c => c.Nombre)
                .Select(c => new ProveedorListDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                })
                .ToList();

        }

        public Proveedor GetProveedorPorId(int proveedorId)
        {
            var proveedorInDb =  _context.Proveedores
                .SingleOrDefault(p => p.Id == proveedorId);
            return proveedorInDb;


        }

    }
}
