using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UdemyDatingApp.API.Data;
using UdemyDatingApp.API.DTOs;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserResponse request)
        {
            if (await UserExists(request.Username.ToLower())) { return BadRequest("Username Taken"); }
            using var hmac = new HMACSHA256();
            var user = new User
            {
                Username = request.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private async Task<bool> UserExists(string Username)
        {
            return await _context.Users.AnyAsync(x=>x.Username==Username);
        }
    }
}
