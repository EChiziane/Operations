using System;
using System.Threading.Tasks;
using Domain;
using Persistence.Contratos;

namespace Application.IServices
{
    public class CarLoadService:ICarLoadService
    {
        private readonly ICarLoadPersist _carLoadPersist;
        private readonly IGeralPersist _geralPersist;

        public CarLoadService(ICarLoadPersist carLoadPersist, IGeralPersist geralPersist)
        {
            _carLoadPersist = carLoadPersist;
            _geralPersist = geralPersist;
        }
        public async Task<CarLoad> AddCarLoad(CarLoad model)
        {
            try
            {
_geralPersist.Add(model);
if (await _geralPersist.SaveChangesAsync())
{
    return await _carLoadPersist.GetCarLoadById(model.Id,false,false,false,false);
}

return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<CarLoad> UpdateCarLoad(int carLoadId, CarLoad model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCarLoad(int carLoadId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CarLoad[]> GetAllCarLoadsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CarLoad[]> GetAllCarLoadByNameAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CarLoad> GetCarLoadByIdAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}