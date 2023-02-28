using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IOperationTypePersist
    {
        Task<OperationType[]> GetAllOperationTypesByDescription(string desription);
        Task<OperationType[]> GetAllOperationTypes();
        Task<OperationType> GetOperationTypeById(int operationTypeId);
    }
}