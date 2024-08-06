using Microsoft.AspNetCore.Authorization;

namespace fsiplanner_backend.Repositories;

public class UsernameRequirement : IAuthorizationRequirement{
    public string Username {get;}

    public UsernameRequirement(string username)
    {
       Username = username;
    }
}