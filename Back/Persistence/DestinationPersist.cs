using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class DestinationPersist : IDestinationPersist
    {
        private readonly OperationContext _context;

        public DestinationPersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<Destination[]> GetAllDestinations()
        {
            IQueryable<Destination> query = _context.Destinations;
            query = query.AsNoTracking().OrderBy(de => de.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Destination> GetDestinationById(int destinationId)
        {
            IQueryable<Destination> query = _context.Destinations;
            query = query.AsNoTracking().OrderBy(de => de.Id).Where(
                de => de.Id == destinationId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Destination[]> GetDestinationByDescription(string description)
        {
            IQueryable<Destination> query = _context.Destinations;
            query = query.AsNoTracking().OrderBy(de => de.Id).Where(
                de => de.Description == description);
            return await query.ToArrayAsync();
        }
        
        public async Task<Destination> GetDestinationByCode(int destinationCode)
        {
            IQueryable<Destination> query = _context.Destinations;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Code == destinationCode);
            return await query.FirstOrDefaultAsync();
        }

    }
}