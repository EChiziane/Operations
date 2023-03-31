using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class ClientService : IClientService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IClientPersist _clientPersist;

        public ClientService(IGeralPersist geralPersist, IClientPersist clientPersist)
        {
            _geralPersist = geralPersist;
            _clientPersist = clientPersist;
        }

        public async Task<Client> AddClient(Client model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _clientPersist.GetClientByIdAsync(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Client> UpdateClient(int userId, Client model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClient(int userId)
        {
            try
            {
                var user = await _clientPersist.GetClientByIdAsync(userId);
                if (user is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(user);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Client[]> GetAllClientsAsync(bool includeBi = false)
        {
            try
            {
                var users = await _clientPersist.GetAllClientsAsync();
                if (users is null) return null;
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Client[]> GetAllClientsByNameAsync(string nome, bool includeBi = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClientByIdAsync(int userId, bool includeBi = false)
        {
            try
            {
                var user = await _clientPersist.GetClientByIdAsync(userId);
                if (user is null) throw new Exception("No userFound");
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<Client[]> GetAllClientsByPhoneAsync(int numero, bool includeBi = false)
        {
            throw new NotImplementedException();
        }
    }
}