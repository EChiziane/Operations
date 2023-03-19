using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IClientService
    {
        Task<Client> AddClient(Client model);
        Task<Client> UpdateClient(int clientId, Client model);
        Task<bool> DeleteClient(int clientId);
        Task<Client[]> GetAllClientsAsync();
        Task<Client[]> GetAllClientByNameAsync();
        Task<Client> GetClientByIdAsync();
    }
}