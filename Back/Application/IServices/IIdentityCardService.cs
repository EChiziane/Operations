using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IIdentityCardService

    {
        Task<IdentityCard> AddIdentityCard(IdentityCard model);
        Task<IdentityCard> UpdateIdentityCard(int id, IdentityCard model);
        Task<bool> Delete(int identityCardId);
        Task<IdentityCard[]> GetAllIdentityCardAsync();
        Task<IdentityCard> GetIdentityCardByIdAsync(int identityCardId);
        Task<IdentityCard[]> GetAllIdentityCardByDescriptionAsync(string description);
    }
}