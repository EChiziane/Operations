using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface ICarLoadService
    {
        Task<CarLoad> AddCarLoad(CarLoad model);
        Task<CarLoad> UpdateCarLoad(int carLoadId, CarLoad model);
        Task<bool> DeleteCarLoad(int carLoadId);
        Task<CarLoad[]> GetAllCarLoadsAsync();
        Task<CarLoad[]> GetAllCarLoadByNameAsync();
        Task<CarLoad> GetCarLoadByIdAsync();
    }
}