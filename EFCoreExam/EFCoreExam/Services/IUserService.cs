using EFCoreExam.Data;
using Microsoft.AspNetCore.Identity;

namespace EFCoreExam.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> CreateUserAsync(string username, string email, string password, string roleName);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<bool> AddRoleToUserAsync(string userId, string roleName);
    }

}
