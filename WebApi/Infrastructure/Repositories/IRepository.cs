using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;
using WebApi.DTO;
using WebApi.Helpers;

namespace WebApi.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
      Task<PagedList<T>> GetAll(ChampionPaginationParamsDto championParamsDto);
      Task<T> Get(int id);
      int Add(T entity);
      int Update(T entity);
      bool Delete(int id);
    }
}
