using Microsoft.EntityFrameworkCore;
using SamaraOrganicsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamaraOrganicsSystem.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SamaraOrganicsServerContext _db;
        public AuthRepository(SamaraOrganicsServerContext db)
        {
            _db = db;
        }
        public async Task<Users> Login(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.PersonFkNavigation.Email == email );

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputeHash.Length; i++)
                {
                    if (ComputeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<Users> Register(Users user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
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

        public async Task<bool> UserExists(string email)
        {
            if (await _db.Users.AnyAsync(x => x.PersonFkNavigation.Email == email))
            {
                return true;
            }
            return false;
        }
    }
}
