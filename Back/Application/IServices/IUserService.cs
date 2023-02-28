using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<User> AddUser(User model);
        Task<User> UpdateUser(int userId, User model);
        Task<bool> DeleteUser(int userId);
        Task<User[]> GetAllUsersAsync(bool includeBi = false);
        Task<User[]> GetAllUserByNameAsync(string nome, bool includeBi = false);
        Task<User> GetUserByIdAsync(int userId, bool includeBi = false);
        Task<User[]> GetAllUserByPhoneAsync(int numero, bool includeBi = false);
    }
}