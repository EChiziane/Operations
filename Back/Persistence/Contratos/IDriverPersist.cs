using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IDriverPersist
    {
        Task<Driver[]> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(int driverId);
        Task<Driver[]> GetDriversByNameAsync(string name);
    }
}