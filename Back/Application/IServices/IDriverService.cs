using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IDriverService
    {
        Task<Driver> AddDriver(Driver model);
        Task<Driver> UpdateDriver(int userId, Driver model);
        Task<bool> DeleteDriver(int userId);
        Task<Driver[]> GetAllDriversAsync(bool includeBi = false);
        Task<Driver[]> GetAllDriversByNameAsync(string nome, bool includeBi = false);
        Task<Driver> GetDriverByIdAsync(int userId, bool includeBi = false);
        Task<Driver[]> GetAllDriversByPhoneAsync(int mobile, bool includeBi = false);
    }
}