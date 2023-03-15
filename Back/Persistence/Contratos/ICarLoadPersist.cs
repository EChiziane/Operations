using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface ICarLoadPersist
    {
        Task<CarLoad[]> GetAllCarLoads(bool includeDestination, bool includeClient, bool includeDriver,
            bool includeMaterial);

        Task<CarLoad> GetCarLoadById(int carloadId, bool includeDestination, bool includeClient, bool includeDriver,
            bool includeMaterial);

        Task<CarLoad[]> GetCarLoadByMaterial(string material, bool includeDestination, bool includeClient,
            bool includeDriver, bool includeMaterial);

        Task<CarLoad[]> GetCarLoadByDestination(string destination, bool includeDestination, bool includeClient,
            bool includeDriver, bool includeMaterial);

        Task<CarLoad[]> GetCarLoadByDriver(string driver, bool includeDestination, bool includeClient,
            bool includeDriver, bool includeMaterial);

        Task<CarLoad[]> GetCarLoadByDate(string date, bool includeDestination, bool includeClient, bool includeDriver,
            bool includeMaterial);
    }
}