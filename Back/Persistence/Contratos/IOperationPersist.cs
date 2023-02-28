using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IOperationPersist
    {
        Task<Operation[]> GetAllOperations(bool includeOperationType=false);
        Task<Operation> GetOperationById(int operationTypeId, bool includeOperationType=false);  
    }
}