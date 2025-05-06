using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;


namespace fsiplanner_backend.Repositories;

public class UserRepository : IUserRepository
{
    private static FSIPlannerDbContext _context;
    private static IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly PasswordHasher<User> _passwordHasher;


    public UserRepository(FSIPlannerDbContext context, IConfiguration config, UserManager<User> userManager)
    {
        _context = context;
        _config = config;
        _userManager = userManager;
        _passwordHasher = new PasswordHasher<User>();
    }


    public async Task<bool> ResetUserPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        // var isTokenValid = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "ResetPassword", token);
        // if (!isTokenValid)
        // {
        //     return false;
        // }

        // user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);


        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }
    private string BuildToken(User user, IList<string> roles)
    {
        var secret = _config.GetValue<string>("TokenSecret");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Name, user.UserName ?? ""),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? "")
    };

        // Add roles as individual claims
        foreach (var role in roles)
        {
            claims.Add(new Claim("role", role));
        }

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
    public async Task<IdentityResult> CreateUserAsync(User user, string password, string role)
    {
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
        return result;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.User.ToList();
    }

    public User GetCurrentUser()
    {
        return _context.User.SingleOrDefault();
    }

    public async Task<IEnumerable<User?>> GetUserByName(string name)
    {
        return await _context.User
            .Where(x => x.FirstName == name || x.LastName == name)
            .ToListAsync();

    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _context.User
                .Where(x => x.UserName == username)
                .SingleOrDefaultAsync();
    }

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        var existingUser = await _userManager.FindByIdAsync(user.Id);
        if (existingUser == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found" });
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.ProfilePicture = user.ProfilePicture;
        existingUser.Role = user.Role;
        var result = await _userManager.UpdateAsync(existingUser);
        return result;
    }

    public async Task<bool> DeleteUserAsync(string username)
    {
        var user = await _context.User
         .Where(x => x.UserName == username)
         .SingleOrDefaultAsync();

        if (user == null)
        {
            return false;
        }

        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> GetUserById(string id)
    {
        return await _context.User.FindAsync(id);
    }
    public async Task<string> SignInAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            return string.Empty;
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
        if (!isPasswordValid)
        {
            return string.Empty;
        }

        var roles = await _userManager.GetRolesAsync(user);
        return BuildToken(user, roles);
    }
}