using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entitites;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService) // This connects us to our database
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")] // POST: api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) // how the data will be sent up to our api
        {
            if(await UserExists(registerDto.Username)) return BadRequest("Username is taken"); // Checking to see if the username already exist in the database

            using var hmac = new HMACSHA512(); // Starts teh process of hashing and saltign the password

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(), // Users username
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)), // Users password Hash
                PasswordSalt = hmac.Key // Users password salt
            };

            _context.Users.Add(user); // adds the user to the database
            await _context.SaveChangesAsync(); // Saves the user asychronously

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

         [HttpPost("login")] // api/account/login

         public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) //
         {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                 x.UserName == loginDto.Username); // Checks the username the user submitted is the same in the database

                if (user == null) return Unauthorized(); // if user login is wrong return null=

                using var hmac = new HMACSHA512(user.PasswordSalt); // The salting of the password that was submitted (Secure)

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); //connects the user submitted salted password to teh database

                for(int i = 0; i < computedHash.Length; i++) // Searches through the database until there is a matched salted password
                {
                    if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password"); // if the database doesnt have the password this message will be dsiplayed
                }

                   return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            }; // If user password is correct in database they will be able to login
         }

        private async Task<bool> UserExists(string username) // its asynmc bc we are checking if the user is already in our database
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());  // usign await bc async method // if user naem exist return true else false
        } 
    }
}