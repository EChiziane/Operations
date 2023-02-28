using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUserPersist _userPersist;

        public UserService(IGeralPersist geralPersist, IUserPersist userPersist)
        {
            _geralPersist = geralPersist;
            _userPersist = userPersist;
        }

        public async Task<User> AddUser(User model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _userPersist.GetUserById(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<User> UpdateUser(int userId, User model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await _userPersist.GetUserById(userId);
                if (user is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(user);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User[]> GetAllUsersAsync(bool includeBi = false)
        {
            try
            {
                var users = await _userPersist.GetAllUsers();
                if (users is null) return null;
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<User[]> GetAllUserByNameAsync(string nome, bool includeBi = false)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(int userId, bool includeBi = false)
        {
            try
            {
                var user = await _userPersist.GetUserById(userId);
                if (user is null) throw new Exception("No userFound");
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<User[]> GetAllUserByPhoneAsync(int numero, bool includeBi = false)
        {
            throw new NotImplementedException();
        }
    }
}