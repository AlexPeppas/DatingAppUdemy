using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync<User>())
                return;

            var usersToSeed = await System.IO.File.ReadAllTextAsync("C:/Users/apeppas/source/repos/UdemyDatingApp/UdemyDatingApp/API/Data/UserSeedingData.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersToSeed);
            foreach (var user in users)
            {
                using var hmac = new HMACSHA256();
                user.Username = user.Username.ToLower();
                //create same dummy password for all seeding data
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@ssw0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
