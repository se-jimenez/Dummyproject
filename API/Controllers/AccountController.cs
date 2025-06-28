using System.Security.Cryptography;
using System.Text;
using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.DTO;
using Microsoft.EntityFrameworkCore;
using API.Services;
using API.Interface;

namespace API.Controllers
{

    public class AccountController(DataContext context, ITokenService tokenService) : BaseAPIController
    {
        [HttpPost("register")]

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Username)) return BadRequest("Username is taken");

            return Ok();

            /* using var hmac = new HMACSHA512();

             var user = new AppUser
             {
                 UserName = registerDTO.Username,
                 PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                 PasswordSalt = hmac.Key
             };

             context.Users.Add(user);
             await context.SaveChangesAsync();

             return new UserDTO
             {
                 Username = user.UserName,
                 Token = tokenService.CreateToken(user)

             }; */
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {

            var normalizedUsername = loginDto.Username.Trim().ToLower();

            var user = await context.Users
         .FirstOrDefaultAsync(x => x.UserName.ToLower() == normalizedUsername);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (computedHash.Length != user.PasswordHash.Length) return Unauthorized("Invalid password");

            for (int i = 0; i < computedHash.Length; i++)

            {

                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDTO
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}
