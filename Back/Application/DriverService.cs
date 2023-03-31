using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class DriverService : IDriverService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IDriverPersist _personPersist;

        public DriverService(IGeralPersist geralPersist, IDriverPersist personPersist)
        {
            _geralPersist = geralPersist;
            _personPersist = personPersist;
        }

        public async Task<Driver> AddDriver(Driver model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _personPersist.GetDriverByIdAsync(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Driver> UpdateDriver(int userId, Driver model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDriver(int userId)
        {
            try
            {
                var user = await _personPersist.GetDriverByIdAsync(userId);
                if (user is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(user);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Driver[]> GetAllDriversAsync(bool includeBi = false)
        {
            try
            {
                var users = await _personPersist.GetAllDriversAsync();
                if (users is null) return null;
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Driver[]> GetAllDriversByNameAsync(string nome, bool includeBi = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverByIdAsync(int userId, bool includeBi = false)
        {
            try
            {
                var user = await _personPersist.GetDriverByIdAsync(userId);
                if (user is null) throw new Exception("No userFound");
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<Driver[]> GetAllDriversByPhoneAsync(int numero, bool includeBi = false)
        {
            throw new NotImplementedException();
        }
    }
}