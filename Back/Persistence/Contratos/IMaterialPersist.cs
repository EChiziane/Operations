using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IMaterialPersist
    {
        Task<Material[]> GetAllMaterials(bool includeMaterialType);
        Task<Material> GetMaterialById(int clientId, bool includeMaterialType);
        Task<Material[]> GetMaterialByName(string name, bool includeMaterialType);
    }
}