using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMaterialTypePersist _materialTypePersist;

        public MaterialTypeService(IMaterialTypePersist materialTypePersist, IGeralPersist geralPersist)
        {
            _materialTypePersist = materialTypePersist;
            _geralPersist = geralPersist;
        }

        public async Task<MaterialType> AddMaterialType(MaterialType model)
        {
            try
            {
                var materialType = await _materialTypePersist.GetMaterialTypeByCode(model.Code);

                if (materialType != null) throw new Exception("Existe Um Material Com este Codigo");


                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync()) ;
                return await _materialTypePersist.GetMaterialTypeById(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MaterialType> UpdateMaterialType(int materialId, MaterialType model)
        {
            try
            {
                var materialType = await _materialTypePersist.GetMaterialTypeById(materialId);
                if (materialType is null)
                    throw new Exception("No Material Type with that Id");
                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _materialTypePersist.GetMaterialTypeById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteMaterialType(int materialId)
        {
            try
            {
                var materialType = await _materialTypePersist.GetMaterialTypeById(materialId);
                if (materialType is null)
                    throw new Exception("No Material Type with that Id");
                _geralPersist.Delete(materialType);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MaterialType[]> GetAllMaterialTypesAsync()
        {
            try
            {
                var materialTypes = await _materialTypePersist.GetAllMaterialTypes();
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MaterialType[]> GetAllMaterialTypeByNameAsync(string nome)
        {
            try
            {
                var materialTypes = await _materialTypePersist.GetMaterialTypeByDescription(nome);
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MaterialType> GetMaterialTypeByCodeAsync(int materialCode)
        {
            try
            {
                var materialTypes = await _materialTypePersist.GetMaterialTypeByCode(materialCode);
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<MaterialType> GetMaterialTypeByIdAsync(int materialId)
        {
            try
            {
                var materialTypes = await _materialTypePersist.GetMaterialTypeById(materialId);
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}