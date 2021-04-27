using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;

namespace DatingApp.API.Interfaces
{
    public interface IUserRepository
    {
        // provide methods for different entities

        // tracks any changes no changes saved to DB
        void Update(AppUser user);

        // updates the DB
        Task<bool> SaveAllAsync();

        // Get all
        Task<IEnumerable<AppUser>> GetUsersAsync();

        // Get user by id
        Task<AppUser> GetUserByIdAsync(int id);

        // Get user by username
        Task<AppUser> GetUserByUsernameAsync(string username);

        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberByUsernameAsync(string username);
    }
}