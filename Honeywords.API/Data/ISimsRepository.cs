using System.Collections.Generic;
using System.Threading.Tasks;
using Honeywords.API.Models;

namespace Honeywords.API.Data
{
    public interface ISimsRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}