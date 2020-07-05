using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Context
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ChampionsContext _context;
        public AuthRepository(ChampionsContext context)
        {
            _context = context;
        }


        public async Task<UserEntity> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == userName);
            if (user ==null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)){
                return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var temporaryHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for (int i=0; i< temporaryHash.Length; i++){
                if (temporaryHash[i] != passwordHash[i]){
                    return false;
                }
            }
            return true;
        }

        public async Task<UserEntity> Register(UserEntity user, string password)
        {
           byte[] passwordHash, passwordSalt;
           CreatePasswordHash(password, out passwordHash, out passwordSalt);
           user.PasswordHash = passwordHash;
           user.PasswordSalt = passwordSalt;

           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();

           return user;
           
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using var hmac = new System.Security.Cryptography.HMACSHA512();
           passwordSalt = hmac.Key;
           passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public async Task<bool> UserExists(string userName)
        {
           if (await _context.Users.AnyAsync(x => x.Login == userName))
           {
           return true;
           }

           return false;
        }

        public async Task<bool> UserIsAdmin(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.Login == userName);
            if (user ==null || user.IsAdmin == false)
            {
            return false;
            }

            return true;
        }
    }
}














