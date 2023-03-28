using System.Threading.Tasks;
using Domain;

namespace Application.IServices
{
    public interface IPersonService
    {
        Task<Person> AddPerson(Person model);
        Task<Person> UpdatePerson(int userId, Person model);
        Task<bool> DeletePerson(int userId);
        Task<Person[]> GetAllPeopleAsync(bool includeBi = false);
        Task<Person[]> GetAllPeopleByNameAsync(string nome, bool includeBi = false);
        Task<Person> GetPersonByIdAsync(int userId, bool includeBi = false);
        Task<Person[]> GetAllPeopleByPhoneAsync(int mobile, bool includeBi = false);
    }
}