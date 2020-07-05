namespace WebApi.Infrastructure.Models
{
    public class UserEntity
    {
        public int Id {get;set;}
        public string Login {get;set;}
        public bool IsAdmin {get;set;}
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt {get;set;}
        
    }
}