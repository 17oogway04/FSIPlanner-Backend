using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;


namespace fsiplanner_backend.Repositories;

public class UserRepository : IUserRepository
{
    private static FSIPlannerDbContext _context;
    private static IConfiguration _config;

    public UserRepository(FSIPlannerDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    private string BuildToken(User user)
    {
        var secret = _config.GetValue<string>("TokenSecret");
        var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));

        var signingCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? "")
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
    }
    public User CreateUser(User user)
    {
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context?.Add(user);
        _context?.SaveChanges();
        return user;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.User.ToList();
    }

    public User GetCurrentUser()
    {
        return _context.User.SingleOrDefault();
    }

    public User GetUserById(int user)
    {
        return _context.User.SingleOrDefault(p => p.UserId == user);
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _context.User
                .Where(x => x.UserName == username)
                .SingleOrDefaultAsync();
    }

    public string SignIn(string username, string password)
    {
        var user = _context.User.SingleOrDefault(x => x.UserName == username);
        var verified = false;

        if(user != null){
            verified = bcrypt.Verify(password, user.Password);
        }

        if(user == null || !verified)
        {
            return string.Empty;
        }

        return BuildToken(user);
    }
}