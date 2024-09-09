using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
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

    private readonly string _salt = "YourSecretSalt";
    public string HashString(string input){
        using(var sha256 = SHA256.Create())
        {
            var saltedInput = input + _salt;
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));
            return Convert.ToBase64String(bytes);
        }
    }

    public string DehashString(string hashedInput)
    {
        throw new NotImplementedException("Hashing it not reversible. Store and match hashes instead");
    }
}