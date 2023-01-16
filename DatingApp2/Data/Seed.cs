using DatingApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatingApp2.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            //se ci sono già degli utenti stoppa l'esecuzione
            if (await context.Users.AnyAsync()) return; 

            //deserializza i dati dal file
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            
            //per ogni utente genera le password x test 
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();

        }
    }
}
