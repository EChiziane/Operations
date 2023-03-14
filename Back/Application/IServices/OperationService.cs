using System;
using System.Threading.Tasks;
using Domain;
using Persistence.Contratos;

namespace Application.IServices
{
    public class OperationService : IOperationService

    {
        private readonly IGeralPersist _geralPersist;
        private readonly IOperationPersist _operationPersist;

        public OperationService(IOperationPersist operationPersist, IGeralPersist geralPersist)
        {
            _operationPersist = operationPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Operation> AddOperations(Operation model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync()) return await _operationPersist.GetOperationById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Operation> UpdateOperation(int operationId, Operation model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOperation(int operationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Operation[]> GetAllOperationAsync(bool includeOperationType = false)
        {
            try
            {
                var operations = await _operationPersist.GetAllOperations(includeOperationType);
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
            throw new NotImplementedException();
        }
    }
}