using DatingApp.API.Models;

namespace DatingApp.API.Interfaces
{
    public interface ITokenService
    {
        //  return string since JWT are just strings
        // receives entity user object
        string CreateToken(Value user);
    }
}