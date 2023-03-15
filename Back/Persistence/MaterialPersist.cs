using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence.Migrations
{
    public class MaterialPersist : IMaterialPersist

    {
        private readonly OperationContext _context;

        public MaterialPersist(OperationContext context)
        {
            _context = context;
        }

        public async Task<Material[]> GetAllMaterials(bool includeMaterialType = false)
        {
            IQueryable<Material> query = _context.Materials.Include(
                ma => ma.MaterialType);
            query = query.AsNoTracking().OrderBy(ma => ma.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Material> GetMaterialById(int materialId, bool includeMaterialType)
        {
            IQueryable<Material> query = _context.Materials.Include(
                ma => ma.MaterialType);
            query = query.AsNoTracking().OrderBy(ma => ma.Id).Where(ma => ma.Id == materialId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Material[]> GetMaterialByName(string name, bool includeMaterialType = false)
        {
            IQueryable<Material> query = _context.Materials.Include(
                ma => ma.MaterialType);
            query = query.AsNoTracking().OrderBy(ma => ma.Id).Where(ma => ma.MaterialType.Description == name);
            return await query.ToArrayAsync();
        }
    }
}