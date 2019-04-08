using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Honeywords.API.Models;

namespace Honeywords.API.Data
{
    public class HoneywordRepository : IHoneywordRepository
    {
        public async void GenerateHoneyWords(DataContext context, User user, int count, string password)
        {
            Random ran = new Random();

            List<string> passwords = new List<string>();

            passwords.Add(password);
            for (int i = 1; i < count; i++)
            {
                passwords.Add(password + ran.Next(100, 999));
            }
            passwords.Shuffle();

            foreach (var pw in passwords)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(pw, out passwordHash, out passwordSalt);
                await context.Passwords.AddAsync(new Password {
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   UserId = user.Id 
                });
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
    public static class CustomExtensions
        {
            public static void Shuffle<T>(this IList<T> list)
            {
                RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                int n = list.Count;
                while (n > 1)
                {
                    byte[] box = new byte[1];
                    do provider.GetBytes(box);
                    while (!(box[0] < n * (Byte.MaxValue / n)));
                    int k = (box[0] % n);
                    n--;
                    T value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
            }

        }
}