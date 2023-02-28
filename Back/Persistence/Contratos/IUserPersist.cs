using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IUserPersist
    {
        Task<User[]> GetUsersByNameAsync(string name);
        Task<User[]> GetAllUsers();
        Task<User> GetUserById(int userId);
    }
}