using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UdemyDatingApp.API.Data;
using UdemyDatingApp.API.DTOs;
using UdemyDatingApp.API.Interfaces;
using UdemyDatingApp.API.Services;
using UdemyDatingApp.Entities;



namespace UdemyDatingApp.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserTokenDTO>> Register(UserDTO request)
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
            return new UserTokenDTO
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string Username)
        {
            return await _context.Users.AnyAsync(x => x.Username == Username);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDTO>> Login(LoginDTO request) 
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            var user = await _context.Users.SingleOrDefaultAsync<User>(x => x.Username == request.Username.ToLower());
            if (user == null) return Unauthorized("Invalid Username");
            //creates hash with the already existed salt 
            using var hmac = new HMACSHA256(user.PasswordSalt);
            
            //check computed hash with stored hash to validate that you have a match
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new UserTokenDTO
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
            
        }
        
        
        

    }
}
