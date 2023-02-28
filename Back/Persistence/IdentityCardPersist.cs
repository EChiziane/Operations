using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class IdentityCardPersist : IIdentityCardPersist

    {
        private readonly OperationContext _context;


        public IdentityCardPersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<IdentityCard[]> GetAllIdentityCardsByName(string desription)
        {
            IQueryable<IdentityCard> query = _context.IdentityCards;
            query = query.AsNoTracking().OrderBy(e => e.FirstName);
            return await query.ToArrayAsync();
        }

        public async Task<IdentityCard[]> GetAllIdentityCards()
        {
            IQueryable<IdentityCard> query = _context.IdentityCards;
            query = query.AsNoTracking().OrderBy(e => e.FirstName);
            return await query.ToArrayAsync();
        }

        public async Task<IdentityCard> GetIdentityCardById(int identityCardId)
        {
            IQueryable<IdentityCard> query = _context.IdentityCards;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == identityCardId);
            return await query.FirstOrDefaultAsync();
        }
    }
}