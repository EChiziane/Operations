using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IMaterialService
    {
        Task<Material> AddMaterial(Material model);
        Task<Material> UpdateMaterial(int materialId, Material model);
        Task<bool> DeleteMaterial(int materialId);
        Task<Material[]> GetAllMaterialsAsync(bool includeMaterialType = false);
        Task<Material[]> GetAllMaterialByNameAsync(string nome, bool includeMaterialType = false);
        Task<Material> GetMaterialByIdAsync(int materialId, bool includeMaterialType = false);
    }
}