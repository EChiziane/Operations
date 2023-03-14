using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IMaterialTypePersist
    {
        Task<MaterialType[]> GetAllMaterialTypes();
        Task<MaterialType> GetMaterialTypeById(int destinationId);
        Task<MaterialType[]> GetMaterialTypeByDescription(string description);
    }
}