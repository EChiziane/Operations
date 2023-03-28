using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class PersonPersist : IPersonPersist
    {
        private readonly OperationContext _context;

        public PersonPersist(OperationContext context)
        {
            _context = context;
        }


        public async Task<Person[]> GetPeopleByNameAsync(string name)
        {
            IQueryable<Person> query = _context.People;
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.FistName.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Person[]> GetAllPeople()
        {
            IQueryable<Person> query = _context.People;
            return await query.ToArrayAsync();
        }

        public async Task<Person> GetPersonById(int operationTypeId)
        {
            IQueryable<Person> query = _context.People;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == operationTypeId);
            return await query.FirstOrDefaultAsync();
        }
    }
}