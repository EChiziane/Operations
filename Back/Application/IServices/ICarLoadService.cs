using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface ICarLoadService
    {
        Task<CarLoad> AddCarLoad(CarLoad model);
        Task<CarLoad> UpdateCarLoad(int carLoadId, CarLoad model);
        Task<bool> DeleteCarLoad(int carLoadId);

        Task<CarLoad[]> GetAllCarLoadsAsync(
            bool includeDestination = false
            , bool includeClient = false
            , bool includeDriver = false
            , bool includeMaterial = false);

        Task<CarLoad[]> GetAllCarLoadByNameAsync(
            string name
            , bool includeDestination = false
            , bool includeClient = false
            , bool includeDriver = false
            , bool includeMaterial = false);

        Task<CarLoad> GetCarLoadByIdAsync(
            int id,
            bool includeDestination = false
            , bool includeClient = false
            , bool includeDriver = false
            , bool includeMaterial = false);
    }
}