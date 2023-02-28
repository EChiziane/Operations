using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IOperationTypeService
    {
        Task<OperationType> AddOperationType(OperationType model);
        Task<OperationType> UpdateOperationType(int id, OperationType model);
        Task<bool> Delete(int operationTypeId);
        Task<OperationType[]> GetAllOperationTypeAsync();
        Task<OperationType> GetOperationTypeByIdAsync(int operationTypeId);
        Task<OperationType[]> GetAllOperationTypeByDescriptionAsync(string description);
    }
}