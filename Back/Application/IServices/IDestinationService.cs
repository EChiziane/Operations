using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IDestinationService
    {
        Task<Destination> AddDestination(Destination model);
        Task<Destination> UpdateDestination(int clientId, Destination model);
        Task<bool> DeleteDestination(int clientId);
        Task<Destination[]> GetAllDestinationsAsync();
        Task<Destination[]> GetAllDestinationByNameAsync();
        Task<Destination> GetDestinationByIdAsync();
    }
}