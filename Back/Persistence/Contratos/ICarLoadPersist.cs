using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface ICarLoadPersist
    {
        Task<CarLoad[]> GetAllCarLoads();
        Task<CarLoad> GetCarLoadById(int carloadId);
        Task<CarLoad[]> GetCarLoadByMaterial(string material);
        Task<CarLoad[]> GetCarLoadByDestination(string destination);
        Task<CarLoad[]> GetCarLoadByDriver(string driver);
        Task<CarLoad[]> GetCarLoadByDate(string date);
    }
}