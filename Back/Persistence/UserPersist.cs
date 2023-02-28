using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class UserPersist : IUserPersist
    {
        private readonly OperationContext _context;

        public UserPersist(OperationContext context)
        {
            _context = context;
        }


        public async Task<User[]> GetUsersByNameAsync(string name)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Name.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsers()
        {
            IQueryable<User> query = _context.Users;
            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserById(int operationTypeId)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == operationTypeId);
            return await query.FirstOrDefaultAsync();
        }
    }
}