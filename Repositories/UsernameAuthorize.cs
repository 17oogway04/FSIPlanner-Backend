using Microsoft.AspNetCore.Authorization;

namespace fsiplanner_backend.Repositories;

public class UsernameRequirement : IAuthorizationRequirement{
    public IEnumerable<string> Username {get;}

    public UsernameRequirement(IEnumerable<string> username)
    {
       Username = username ?? throw new ArgumentNullException(nameof(username));
    }
}