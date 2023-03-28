using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class PersonService : IPersonService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPersonPersist _personPersist;

        public PersonService(IGeralPersist geralPersist, IPersonPersist personPersist)
        {
            _geralPersist = geralPersist;
            _personPersist = personPersist;
        }

        public async Task<Person> AddPerson(Person model)
        {
            try
            {
                _geralPersist.Add(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _personPersist.GetPersonById(model.Id);
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Person> UpdatePerson(int userId, Person model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePerson(int userId)
        {
            try
            {
                var user = await _personPersist.GetPersonById(userId);
                if (user is null) throw new Exception("No Operation Type with this id");
                _geralPersist.Delete(user);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Person[]> GetAllPeopleAsync(bool includeBi = false)
        {
            try
            {
                var users = await _personPersist.GetAllPeople();
                if (users is null) return null;
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Person[]> GetAllPeopleByNameAsync(string nome, bool includeBi = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetPersonByIdAsync(int userId, bool includeBi = false)
        {
            try
            {
                var user = await _personPersist.GetPersonById(userId);
                if (user is null) throw new Exception("No userFound");
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<Person[]> GetAllPeopleByPhoneAsync(int numero, bool includeBi = false)
        {
            throw new NotImplementedException();
        }
    }
}