using System;
using System.Threading.Tasks;
using Domain;
using Persistence.Contratos;

namespace Application.IServices
{
    public class CarLoadService : ICarLoadService
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
                    return await _carLoadPersist.GetCarLoadById(model.Id,
                        false,
                        false,
                        false,
                        false);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<CarLoad> UpdateCarLoad(int carLoadId, CarLoad model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCarLoad(int carLoadId)
        {
            try
            {
                var carload = await _carLoadPersist.GetCarLoadById(
                    carLoadId,
                    false,
                    false,
                    false,
                    false);
                if (carload is null) throw new Exception("No Carload Found with id: " + carLoadId);
                _geralPersist.Delete(carload);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CarLoad[]> GetAllCarLoadsAsync(
            bool includeDestination = false
            , bool includeClient = false
            , bool includeDriver = false,
            bool includeMaterial = false)
        {
            try
            {
                var carLoads = await _carLoadPersist.GetAllCarLoads(
                    includeDestination
                    , includeClient,
                    includeDriver
                    , includeMaterial);
                if (carLoads is null) return null;
                return carLoads;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<CarLoad[]> GetAllCarLoadByNameAsync(
            string material,
            bool includeDestination = false, 
            bool includeClient = false,
            bool includeDriver = false,
            bool includeMaterial = false)
        {
            try
            {
                var carload = _carLoadPersist.GetCarLoadByDriver(
                    material,
                    includeDestination,
                    includeClient,
                    includeDriver,
                    includeMaterial);
                if (carload is null) throw new Exception("CarLoad not found");
                return carload;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<CarLoad> GetCarLoadByIdAsync(
            int id,
            bool includeDestination = false, 
            bool includeClient = false,
            bool includeDriver = false,
            bool includeMaterial = false)
        {
            try
            {
                var carload = _carLoadPersist.GetCarLoadById(
                    id,
                    includeDestination,
                    includeClient,
                    includeDriver,
                    includeMaterial);
                if (carload is null) throw new Exception("CarLoad not found");
                return carload;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}