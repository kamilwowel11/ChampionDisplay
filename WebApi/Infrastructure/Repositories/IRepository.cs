using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
      Task<IEnumerable<T>> GetAll();
      Task<T> Get(int id);
      int Add(T entity);
      int Update(T entity);
      bool Delete(int id);
    }
}
