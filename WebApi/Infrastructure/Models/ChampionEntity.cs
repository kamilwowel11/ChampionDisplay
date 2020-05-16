namespace WebApi.Infrastructure.Models
{
    public class ChampionEntity : BaseEntity
    { 
        public string FirstName {get;set;}
        public string DefaultPosition {get;set;}
        public string Bio {get;set;}
        public string AvatarUrl {get;set;}
        public string PictureUrl {get;set;}
  }
}
