using System.Threading.Tasks;
using Domain;

namespace Persistence.Contratos
{
    public interface IPersonPersist
    {
        Task<Person[]> GetPeopleByNameAsync(string name);
        Task<Person[]> GetAllPeople();
        Task<Person> GetPersonById(int personId);
    }
}