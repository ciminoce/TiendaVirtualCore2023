using Microsoft.EntityFrameworkCore;
using TiendaVirtualCore.Data.Interfaces;
using TiendaVirtualCore.Entities.Dtos.Pais;
using TiendaVirtualCore.Entities.Models;

namespace TiendaVirtualCore.Data.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        private readonly NeptunoDbContext _context;

        public RepositorioPaises(NeptunoDbContext context)
        {
            _context = context;
        }


        public void Agregar(Pais pais)
        {
            var nuevoPais = new Pais()
            {
                NombrePais = pais.NombrePais
            };
            _context.Paises.Add(nuevoPais);


        }

        public void Borrar(int id)
        {
            var paisInDb =_context.Paises
                .SingleOrDefault(p => p.PaisId == id);
            if (paisInDb == null)
            {
                Exception ex = new Exception("Borrado por otro usuario");
                throw ex;
            }
            _context.Entry(paisInDb).State = EntityState.Deleted;


        }

        public void Editar(Pais pais)
        {
                var paisInDb = _context.Paises
                .SingleOrDefault(c => c.PaisId == pais.PaisId);
                if (paisInDb == null)
                {
                    throw new Exception("Borrado por otro usuario");
                }
                paisInDb.NombrePais = pais.NombrePais;
                paisInDb.RowVersion = pais.RowVersion;
                _context.Entry(paisInDb).State = EntityState.Modified;


        }

        public bool EstaRelacionado(Pais pais)
        {
            return false;
        }

        public bool Existe(Pais pais)
        {
            if (pais.PaisId == 0)
            {
                return _context.Paises
                    .Any(p => p.NombrePais == pais.NombrePais);
            }
            return _context.Paises
                .Any(p => p.NombrePais == pais.NombrePais && p.PaisId != pais.PaisId);


        }

        public int GetCantidad()
        {
            return _context.Paises.Count();
        }

        public List<PaisListDto> GetPaises()
        {
            return _context.Paises
                .OrderBy(c => c.NombrePais)
                .Select(c => new PaisListDto
                {
                    PaisId = c.PaisId,
                    NombrePais = c.NombrePais,
                })
                .ToList();

        }

        public Pais GetPaisPorId(int paisId)
        {
            var paisInDb =  _context.Paises
                .SingleOrDefault(p => p.PaisId == paisId);
            return paisInDb;


        }

    }
}
