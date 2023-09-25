using Microsoft.EntityFrameworkCore;

namespace TiendaVirtualCore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NeptunoDbContext _context;

        public UnitOfWork(NeptunoDbContext context)
        {
            _context = context;
        }


        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

    }
}
