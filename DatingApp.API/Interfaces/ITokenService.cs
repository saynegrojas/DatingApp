using DatingApp.API.Entities;

namespace DatingApp.API.Interfaces
{
    public interface ITokenService
    {
        //  return string since JWT are just strings
        // receives entity user object
        string CreateToken(AppUser user);
    }
}