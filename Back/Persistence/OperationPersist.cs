using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class OperationPersist : IOperationPersist
    {
        private readonly OperationContext _context;

        public OperationPersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<Operation[]> GetAllOperations(bool includeOperationType = false)
        {
            IQueryable<Operation> query = _context.Operations
                .Include(op => op.OperationType);
            query = query.AsNoTracking().OrderBy(op => op.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Operation> GetOperationById(int operationId, bool includeOperationType = false)
        {
            IQueryable<Operation> query = _context.Operations
                .Include(op => op.OperationType);
            ;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == operationId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Operation[]> GetAllOperations()
        {
            IQueryable<Operation> query = _context.Operations;
            return await query.ToArrayAsync();
        }
    }
}