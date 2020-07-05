using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class UserToRegisterDto
    {
        [Required]
        public string Login {get; set;}
        [Required]
        [StringLength(60,MinimumLength = 8, ErrorMessage = "Błąd ! Hasło musi zawierać się w przedziale od 8 do 60 znaków")]
        public string Password {get; set;}
        
    }

}