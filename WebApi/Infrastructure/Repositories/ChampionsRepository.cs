using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Context;
using WebApi.Infrastructure.Models;
using WebApi.DTO;
using WebApi.Helpers;

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

    public async Task<PagedList<ChampionEntity>> GetAll(ChampionPaginationParamsDto championParamsDto)
    {
      //return await context.Champions.ToListAsync();
      var champions = context.Champions.AsQueryable();

      // Filtr
      if (!String.IsNullOrEmpty(championParamsDto.FirstName))
      {
        champions = champions.Where(x => x.FirstName == championParamsDto.FirstName);
      }
      if (!String.IsNullOrEmpty(championParamsDto.DefaultPosition))
      {
        champions = champions.Where(x => x.DefaultPosition == championParamsDto.DefaultPosition);
      }

      switch (championParamsDto.OrderBy)
      {
        case "firstName":
          champions = champions.OrderBy(x => x.FirstName);
          break;
        case "firstNameDescending":
          champions = champions.OrderByDescending(x => x.FirstName);
          break;
        case "defaultPosition":
          champions = champions.OrderByDescending(x => x.DefaultPosition);
          break;
        case "defaultPositionDescending":
          champions = champions.OrderByDescending(x => x.DefaultPosition);
          break;


      }

      return await PagedList<ChampionEntity>.CreateAsync(champions, championParamsDto.PageNumber, championParamsDto.PageSize);
    }

    public int Update(ChampionEntity entity)
    {
      context.Champions.Update(entity);
      context.SaveChanges();
      return entity.Id;
    }
  }
}
