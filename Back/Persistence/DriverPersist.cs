using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class DriverPersist : IDriverPersist
    {
        private readonly OperationContext _context;

        public DriverPersist(OperationContext context)
        {
            _context = context;
        }


        public async Task<Driver[]> GetDriversByNameAsync(string name)
        {
            IQueryable<Driver> query = _context.Drivers;
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.FirstName.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Driver[]> GetAllDriversAsync()
        {
            IQueryable<Driver> query = _context.Drivers;
            return await query.ToArrayAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(int operationTypeId)
        {
            IQueryable<Driver> query = _context.Drivers;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == operationTypeId);
            return await query.FirstOrDefaultAsync();
        }

       
    }
}