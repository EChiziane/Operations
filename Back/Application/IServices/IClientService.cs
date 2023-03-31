using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IClientService
    {
        Task<Client> AddClient(Client model);
        Task<Client> UpdateClient(int userId, Client model);
        Task<bool> DeleteClient(int userId);
        Task<Client[]> GetAllClientsAsync(bool includeBi = false);
        Task<Client[]> GetAllClientsByNameAsync(string nome, bool includeBi = false);
        Task<Client> GetClientByIdAsync(int userId, bool includeBi = false);
        Task<Client[]> GetAllClientsByPhoneAsync(int mobile, bool includeBi = false);
    }
}