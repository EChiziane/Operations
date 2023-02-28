using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class OperationTypePersist : IOperationTypePersist
    {
        private readonly OperationContext _context;

        public OperationTypePersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<OperationType[]> GetAllOperationTypesByDescription(string description)
        {
            IQueryable<OperationType> query = _context.OperationTypes;
            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Description.ToLower().Contains(description.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<OperationType[]> GetAllOperationTypes()
        {
            IQueryable<OperationType> query = _context.OperationTypes;
            return await query.ToArrayAsync();
        }

        public async Task<OperationType> GetOperationTypeById(int operationTypeId)
        {
            IQueryable<OperationType> query = _context.OperationTypes;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == operationTypeId);
            return await query.FirstOrDefaultAsync();
        }
    }
}