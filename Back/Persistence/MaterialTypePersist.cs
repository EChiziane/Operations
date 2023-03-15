using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence.Migrations
{
    public class MaterialTypePersist:IMaterialTypePersist
    {
        private readonly OperationContext _context;

        public MaterialTypePersist(OperationContext context)
        {
            _context = context;
        }
        
        public async Task<MaterialType[]> GetAllMaterialTypes()
        {
            IQueryable<MaterialType> query = _context.MaterialTypes;
            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<MaterialType> GetMaterialTypeById(int materialTypeId)
        {
            IQueryable<MaterialType> query = _context.MaterialTypes;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e=>e.Id==materialTypeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<MaterialType[]> GetMaterialTypeByDescription(string description)
        {
            IQueryable<MaterialType> query = _context.MaterialTypes;
            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e=>e.Description==description);
            return await query.ToArrayAsync();
        }
    }
}