using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IDestinationService
    {
        Task<Destination> AddDestination(Destination model);
        Task<Destination> UpdateDestination(int destinationId, Destination model);
        Task<bool> DeleteDestination(int destinationId);
        Task<Destination[]> GetAllDestinationsAsync();
        Task<Destination[]> GetAllDestinationByNameAsync(string name);
        Task<Destination> GetDestinationByCodeAsync(int destinationCode);
        Task<Destination> GetDestinationByIdAsync(int destinationId);
    }
}