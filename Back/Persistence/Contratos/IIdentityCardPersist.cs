using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IIdentityCardPersist
    {
        Task<IdentityCard[]> GetAllIdentityCardsByName(string name);
        Task<IdentityCard[]> GetAllIdentityCards();
        Task<IdentityCard> GetIdentityCardById(int identityCardId);
    }
}