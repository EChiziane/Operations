using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class ClientPersist : IClientPersist
    {
        private readonly OperationContext _context;

        public ClientPersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<Client[]> GetAllClients()
        {
            IQueryable<Client> query = _context.Clients;
            query = query.AsNoTracking().OrderBy(cl => cl.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Client> GetClientById(int clientId)
        {
            IQueryable<Client> query = _context.Clients;
            query = query.AsNoTracking().OrderBy(cl => cl.Id).Where(cl => cl.Id == clientId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Client[]> GetClientByName(string name)
        {
            IQueryable<Client> query = _context.Clients;
            query = query.AsNoTracking().OrderBy(cl => cl.Id).Where(cl => cl.FistName == name);
            return await query.ToArrayAsync();
        }
    }
}