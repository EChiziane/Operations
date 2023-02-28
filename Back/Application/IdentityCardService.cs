using System;
using System.Threading.Tasks;
using Domain;
using Persistence.Contratos;

namespace Application.IServices
{
    public class IdentityCardService : IIdentityCardService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IIdentityCardPersist _identityCardPersist;

        public IdentityCardService(IGeralPersist geralPersist, IIdentityCardPersist identityCardPersist)
        {
            _geralPersist = geralPersist;
            _identityCardPersist = identityCardPersist;
        }

        public async Task<IdentityCard> AddIdentityCard(IdentityCard model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _identityCardPersist.GetIdentityCardById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IdentityCard> UpdateIdentityCard(int id, IdentityCard model)
        {
            try
            {
                var identityCard = await _identityCardPersist.GetIdentityCardById(model.Id);
                if (identityCard is null)
                    throw new Exception(" No operation Type with this code");
                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _identityCardPersist.GetIdentityCardById(model.Id);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int identityCardId)
        {
            try
            {
                var identityCard = await _identityCardPersist.GetIdentityCardById(identityCardId);
                if (identityCard is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(identityCard);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IdentityCard[]> GetAllIdentityCardAsync()
        {
            try
            {
                var identityCards = await _identityCardPersist.GetAllIdentityCards();
                if (identityCards is null) return null;
                return identityCards;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IdentityCard> GetIdentityCardByIdAsync(int identityCardId)
        {
            try
            {
                var identityCard = await _identityCardPersist.GetIdentityCardById(identityCardId);
                if (identityCard is null) throw new Exception("No identityCardFound");
                return identityCard;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<IdentityCard[]> GetAllIdentityCardByDescriptionAsync(string description)
        {
            throw new NotImplementedException();
        }
    }
}