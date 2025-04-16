using fsiplanner_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace fsiplanner_backend.Repositories;

public interface IUserRepository
{
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<string> SignInAsync(string username, string password);
    User GetCurrentUser();
    Task<User> GetUserById(string id);
    IEnumerable<User> GetAllUsers();
    Task<IEnumerable<User?>> GetUserByName(string name);
    Task<User?> GetUserByUsername(string username);
    Task<bool> DeleteUserAsync(string username);
    Task<IdentityResult> UpdateUserAsync(User user);
    Task<bool> ResetUserPasswordAsync(string email, string token, string newPassword);
}