using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IClientPersist
    {
        Task<Client[]> GetAllClients();
        Task<Client> GetClientById(int clientId);
        Task<Client[]> GetClientByName(string name);
    }
}