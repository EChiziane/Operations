using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class OperationTypeService : IOperationTypeService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IOperationTypePersist _operationTypePersist;


        public OperationTypeService(IGeralPersist geralPersist, IOperationTypePersist operationTypePersist)
        {
            _geralPersist = geralPersist;
            _operationTypePersist = operationTypePersist;
        }

        public async Task<OperationType> AddOperationType(OperationType model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _operationTypePersist.GetOperationTypeById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationType> UpdateOperationType(int id, OperationType model)
        {
            try
            {
                var operationType = await _operationTypePersist.GetOperationTypeById(model.Id);
                if (operationType is null)
                    throw new Exception(" No operation Type with this code");
                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _operationTypePersist.GetOperationTypeById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int operationTypeId)
        {
            try
            {
                var operationType = await _operationTypePersist.GetOperationTypeById(operationTypeId);
                if (operationType is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(operationType);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationType[]> GetAllOperationTypeAsync()
        {
            try
            {
                var operationTypes = await _operationTypePersist.GetAllOperationTypes();
                if (operationTypes is null) return null;
                return operationTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationType> GetOperationTypeByIdAsync(int operationTypeId)
        {
            try
            {
                var operationType = await _operationTypePersist.GetOperationTypeById(operationTypeId);
                if (operationType is null) throw new Exception("No operationTypeFound");
                return operationType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<OperationType[]> GetAllOperationTypeByDescriptionAsync(string description)
        {
            throw new NotImplementedException();
        }
    }
}