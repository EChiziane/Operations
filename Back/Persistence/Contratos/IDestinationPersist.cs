using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IDestinationPersist
    {
        Task<Destination[]> GetAllDestinations();
        Task<Destination> GetDestinationById(int destinationId);
        Task<Destination[]> GetDestinationByDescription(string description);
    }
}