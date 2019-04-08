using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Honeywords.API.Models;

namespace Honeywords.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        private readonly IHoneywordRepository honeypot;
        public AuthRepository(DataContext context, IHoneywordRepository honeypot)
        {
            this.context = context;
            this.honeypot = honeypot;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await this.context.Users.Include(p => p.Passwords).FirstOrDefaultAsync(x => x.Username == username);
            if (user == null) {
                return null;
            }
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) {
            //     return null;
            // }
            if (!VerifyPasswordHash(user, password))
            {
                return null;
            }
            return user;
        }

        // private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        // {
        //     using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //     {
        //         var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //         for (int i = 0; i < computedHash.Length; i++) {
        //             if (computedHash[i] != passwordHash[i]) {
        //                 return false;
        //             }
        //         }
        //         return true;
        //     }
        // }
        private bool VerifyPasswordHash(User user, string password)
        {
            var passwords = user.Passwords;
            foreach (var pw in passwords)
            {
                bool found = false;
                using (var hmac = new System.Security.Cryptography.HMACSHA512(pw.PasswordSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++) {
                        if (computedHash[i] != pw.PasswordHash[i])
                        {
                            found = false;
                            break;
                        } else {
                            found = true;
                        }
                    }
                }
                if (found)
                {
                    return true;
                }

            }
            return false;
        }

        public async Task<User> Register(User user, string password)
        {
            // byte[] passwordHash, passwordSalt;
            // CreatePasswordHash(password, out passwordHash, out passwordSalt);
            // user.PasswordHash = passwordHash;
            // user.PasswordSalt = passwordSalt;

            await this.context.Users.AddAsync(user);
            this.honeypot.GenerateHoneyWords(this.context, user, 5, password);
            
            await this.context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await this.context.Users.AnyAsync(x => x.Username == username)) {
                return true;
            }
            return false;
        }
    }
}