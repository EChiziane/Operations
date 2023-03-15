using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IMaterialTypeTypeService
    {
        Task<MaterialType> AddMaterialType(MaterialType model);
        Task<MaterialType> UpdateMaterialType(int materialId, MaterialType model);
        Task<bool> DeleteMaterialType(int materialId);
        Task<MaterialType[]> GetAllMaterialTypesAsync();
        Task<MaterialType[]> GetAllMaterialTypeByNameAsync(string nome);
        Task<MaterialType> GetMaterialTypeByIdAsync(int materialId);
    }
}