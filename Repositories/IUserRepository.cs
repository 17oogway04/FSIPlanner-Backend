using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IUserRepository
{
    User CreateUser (User user);
    string SignIn(string username, string password);
    User GetCurrentUser();
    User GetUserById(int user);
    IEnumerable<User> GetAllUsers();
   Task<IEnumerable<User?>> GetUserByName(string name);
   Task<User?> GetUserByUsername(string username);

    Task<User?> GetUserByHashedUsername(string hashedUsername);

    Task<User?> GetUserByHashedUserId(string hashedUserId);
   void UpdateUser(User user);
}