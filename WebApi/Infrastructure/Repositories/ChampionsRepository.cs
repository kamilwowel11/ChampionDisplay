using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Context;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Repositories
{
  public class ChampionsRepository : IRepository<ChampionEntity>
  {
    private readonly ChampionsContext context;

    public ChampionsRepository(ChampionsContext context)
    {
      this.context = context;
    }
    public int Add(ChampionEntity entity)
    {
      context.Add(entity);
      context.SaveChanges();
      return entity.Id;
    }

    public bool Delete(int id)
    {
      var entityToRemove = context.Champions.Find(id);
      if(entityToRemove!=null)
      {
        context.Remove(entityToRemove);
        context.SaveChanges();
        return true;
      }
      return false;        
    }

    public async Task<ChampionEntity> Get(int id)
    {
      return await context.Champions.FirstOrDefaultAsync(e => e.Id==id);
    }

    public async Task<IEnumerable<ChampionEntity>> GetAll()
    {
      return await context.Champions.ToListAsync();
    }

    public int Update(ChampionEntity entity)
    {
      context.Champions.Update(entity);
      context.SaveChanges();
      return entity.Id;
    }
  }
}
