using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IUserRepository
{
    User CreateUser (User user);
    string SignIn(string username, string password);
    User GetCurrentUser();
    User GetUserById(int user);
    IEnumerable<User> GetAllUsers();
    Task<User?> GetUserByUsername(string username);
}