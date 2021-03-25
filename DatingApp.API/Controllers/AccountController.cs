using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Interfaces;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        // inject tokenService & init field param
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        // REGISTER
        // error when sending params in a body of a request, must send it as an object type 
        // passing in a DTO object as the type

        // we are now return a DTO of UserDto instead of Entity Value
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {

            // call method to check if user exists by comparing passed in username & exisiting usernames in db
            if (await UserAlreadyExists(register.Username)) return BadRequest("Username already exists");

            using var hmac = new HMACSHA512();

            //need to make pw string into a btye array
            //generate pwhash - gives us a random generated key
            //generate pw salt - we set the pwhash to key
            var user = new Value
            {
                // use tolower to compare username we get from registerDTO with passed in username
                UserName = register.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                PasswordSalt = hmac.Key
            };
            // add user to table, but add does not add it to db, it tracks the entity in EF
            _context.Add(user);
            // calls our db & add user to table
            await _context.SaveChangesAsync();

            // we now return a DTO w/ specified properties
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        // LOGIN
        // will take in an object with username & pw
        // find username & match hash/salt pw
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            // find user in our db
            // we match the username from our db from the passed in username of our object
            var user = await _context.Values.SingleOrDefaultAsync(x => x.UserName == login.Username);

            // check if username is null
            if (user == null) return Unauthorized("Invalid username");

            // reverse hash using the overloaded method in HMAC that takes in secret key(PWSalt) from our db
            using var hmac = new HMACSHA512(user.PasswordSalt);

            // hash the pw we pass in as a param
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            // loop through byte array, compare passed in computedHash with the computedHash in our db
            for (int i = 0; i < computedHash.Length; i++)
            {
                // matching each element of hashed passed in pw with db hashed pw 
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new UserDto {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        // create a method which will check if username already exists
        private async Task<bool> UserAlreadyExists(string username)
        {
            // make sure to use toLower to compare passed in username with username in DTO
            return await _context.Values.AnyAsync(value => value.UserName == username.ToLower());
        }
    }
}