using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Categoria;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly NeptunoDbContext _context;

        public RepositorioCategorias(NeptunoDbContext context)
        {
            _context = context;
        }


        public void Agregar(Categoria categoria)
        {
            var nuevaCategoria = new Categoria()
            {
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
            };
            _context.Categorias.Add(nuevaCategoria);


        }

        public void Borrar(int id)
        {
            var categoriaInDb =_context.Categorias
                .SingleOrDefault(p => p.CategoriaId == id);
            if (categoriaInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(categoriaInDb).State = EntityState.Deleted;


        }

        public void Editar(Categoria categoria)
        {
                var categoriaInDb = _context.Categorias
                .SingleOrDefault(c => c.CategoriaId == categoria.CategoriaId);
                if (categoriaInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                categoriaInDb.NombreCategoria = categoria.NombreCategoria;
                categoriaInDb.Descripcion = categoria.Descripcion;
                categoriaInDb.RowVersion = categoria.RowVersion;
                _context.Entry(categoriaInDb).State = EntityState.Modified;


        }

        public bool EstaRelacionado(Categoria categoria)
        {
            return false;
        }

        public bool Existe(Categoria categoria)
        {
            if (categoria.CategoriaId == 0)
            {
                return _context.Categorias
                    .Any(p => p.NombreCategoria == categoria.NombreCategoria);
            }
            return _context.Categorias
                .Any(p => p.NombreCategoria == categoria.NombreCategoria && p.CategoriaId != categoria.CategoriaId);


        }

        public int GetCantidad()
        {
            return _context.Categorias.Count();
        }

        public List<CategoriaListDto> GetCategorias()
        {
            return _context.Categorias
                .OrderBy(c => c.NombreCategoria)
                .Select(c => new CategoriaListDto
                {
                    CategoriaId = c.CategoriaId,
                    NombreCategoria = c.NombreCategoria,
                })
                .ToList();

        }

        public Categoria GetCategoriaPorId(int categoriaId)
        {
            var categoriaInDb =  _context.Categorias
                .SingleOrDefault(p => p.CategoriaId == categoriaId);
            return categoriaInDb;


        }

    }
}
