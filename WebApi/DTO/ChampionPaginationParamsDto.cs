namespace WebApi.DTO
{
  public class ChampionPaginationParamsDto
  {
        public int PageSize {get;set;} = 10;
        public int PageNumber { get; set; } = 1 ;

        // Filrt
        public string FirstName { get; set;}
        public string DefaultPosition { get; set; }

        public string OrderBy {get; set;}
    }
}
