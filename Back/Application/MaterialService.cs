using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialPersist _materialPersist;
        private readonly IGeralPersist _geralPersist;

        public MaterialService(IMaterialPersist materialPersist, IGeralPersist geralPersist)
        {
            _materialPersist = materialPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Material> AddMaterial(Material model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync()) ;
                return await _materialPersist.GetMaterialById(model.Id, false);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Material> UpdateMaterial(int materialId, Material model)
        {
            try
            {
                var material = await _materialPersist.GetMaterialById(materialId, false);
                if (material is null)
                    throw new Exception("No Material Type with that Id");
                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _materialPersist.GetMaterialById(model.Id, true);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteMaterial(int materialId)
        {
            try
            {
                var material = await _materialPersist.GetMaterialById(materialId, false);
                if (material is null)
                    throw new Exception("No Material Type with that Id");
                _geralPersist.Delete(material);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Material[]> GetAllMaterialsAsync(bool includeMaterial = false)
        {
            try
            {
                var materialTypes = await _materialPersist.GetAllMaterials(includeMaterial);
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Material[]> GetAllMaterialByNameAsync(string nome, bool includeMaterial = false)
        {
            try
            {
                var materialTypes = await _materialPersist.GetMaterialByName(nome, includeMaterial);
                if (materialTypes is null) return null;
                return materialTypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Material> GetMaterialByIdAsync(int materialId, bool includeMaterial = false)
        {
            try
            {
                var materialTypes = await _materialPersist.GetMaterialById(materialId, includeMaterial);
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