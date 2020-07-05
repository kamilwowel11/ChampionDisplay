using System.Threading.Tasks;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Context
{
    public interface IAuthRepository{

        Task<UserEntity> Register(UserEntity user, string password);
        Task<UserEntity> Login(string userName, string password);
        Task<bool> UserExists(string userName);
        Task<bool> UserIsAdmin(string userName);
        
    }
}














