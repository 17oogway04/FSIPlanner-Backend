using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace fsiplanner_backend.Repositories;

public class UsernameRequirementHandler : AuthorizationHandler<UsernameRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsernameRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var username = context.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value; // Assuming the username is stored in the Name property
            if (username != null && requirement.Username.Contains(username))
            {
                context.Succeed(requirement);
            }
            else
            {
                {
                    // For debugging purposes
                    Console.WriteLine($"Username in token: {username}");
                    Console.WriteLine($"Required username: {requirement.Username}");
                }
            }
        }
        else
        {


            // For debugging purposes
            Console.WriteLine("User is not authenticated.");

        }
        return Task.CompletedTask;
    }
}