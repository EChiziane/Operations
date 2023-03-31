using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IClientPersist
    {
        Task<Client[]> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int clientId);
        Task<Client[]> GetClientByNameAsync(string name);
    }
}