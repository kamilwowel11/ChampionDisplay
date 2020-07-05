using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class UserForLoginDto
    {
        public string Login {get; set;}
        public string Password {get; set;}
        
    }

}