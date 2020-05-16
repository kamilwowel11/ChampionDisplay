using AutoMapper;
using WebApi.Infrastructure.Models;
using WebApi.Infrastructure.ViewModels;

namespace WebApi.Infrastructure.Mapping
{
    public class ChampionMappingProfile : Profile
    {
        public ChampionMappingProfile()
        {
          CreateMap<ChampionEntity, ChampionViewModel>();
          CreateMap<ChampionViewModel, ChampionEntity>();
        }
    }
}
