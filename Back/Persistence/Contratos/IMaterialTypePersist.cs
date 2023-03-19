﻿using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IMaterialTypePersist
    {
        Task<MaterialType[]> GetAllMaterialTypes();
        Task<MaterialType> GetMaterialTypeById(int materialId);
        Task<MaterialType> GetMaterialTypeByCode(int materialCode);
        Task<MaterialType[]> GetMaterialTypeByDescription(string description);
    }
}