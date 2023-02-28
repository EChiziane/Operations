using System;
using System.Threading.Tasks;
using Domain;
using Persistence.Contratos;

namespace Application.IServices
{
    public class OperationService:IOperationService
    
    {
        private readonly IOperationPersist _operationPersist;
        private readonly IGeralPersist _geralPersist;

        public OperationService(IOperationPersist operationPersist,IGeralPersist geralPersist)
        {
            _operationPersist = operationPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Operation> AddOperations(Operation model)
        {
            try
            {
                _geralPersist.Add<Operation>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _operationPersist.GetOperationById(model.Id, false);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Operation> UpdateOperation(int operationId, Operation model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteOperation(int operationId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Operation[]> GetAllOperationAsync(bool includeOperationType = false)
        {
            try
            {
                var operations = await _operationPersist.GetAllOperations((includeOperationType));
                if (operations is null) return null;
                return operations;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Operation> GetOperationByIdAsync(int operationId, bool includeOperationType = false)
        {
            throw new System.NotImplementedException();
        }
    }
}