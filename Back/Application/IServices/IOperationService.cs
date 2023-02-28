using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IOperationService
    {
        Task<Operation> AddOperations(Operation model);
        Task<Operation> UpdateOperation(int operationId, Operation model);
        Task<bool> DeleteOperation(int operationId);

        Task<Operation[]> GetAllOperationAsync(bool includeOperationType = false);
        Task<Operation> GetOperationByIdAsync(int operationId, bool includeOperationType = false);
    }
}