using System.Security.Claims;
using fsiplanner_backend.Models;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _env;

        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public UserController(ILogger<UserController> logger, IUserRepository repository, IWebHostEnvironment env, UserManager<User> userManager, IEmailService emailService)
        {
            _logger = logger;
            _userRepository = repository;
            _env = env;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] PasswordResetRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetUrl = $"https://localhost:8100.com/reset-password?token={Uri.EscapeDataString(token)}&email={request.Email}";

            await _emailService.SendEmailAsync(user.Email, "Password Reset", $"Reset your password by clicking here: {resetUrl}");

            return Ok("Password reset link sent to email");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("User not found.");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid token or password reset failed.");
            }

            return Ok("Password reset successfully");
        }
        [HttpPost]
        [Route("register")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CreateUser([FromBody] User request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // You could validate role input if coming from frontend
            var role = string.IsNullOrEmpty(request.Role) ? "User" : request.Role;

            var user = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NormalizedUserName = request.UserName.ToUpper(),
                Password = request.Password
            };

            var result = await _userRepository.CreateUserAsync(user, request.Password, role);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var createdUser = await _userRepository.GetUserByUsername(user.UserName);
            var roles = await _userManager.GetRolesAsync(createdUser);

            return Ok(new{User = createdUser, Roles = roles});
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<string>> SignIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Username and password are required");
            }

            var token = await _userRepository.SignInAsync(username, password);

            if (string.IsNullOrWhiteSpace(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet]
        [Route("current")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult GetCurrentUser()
        {
            bool isLoggedIn = User.Identity!.IsAuthenticated;
            if (!isLoggedIn)
            {
                return NotFound();
            }

            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            var currentUser = _userRepository.GetUserById(id);


            return Ok(currentUser);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("{name}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByName(string name)
        {
            IEnumerable<User> names = (IEnumerable<User>)await _userRepository.GetUserByName(name);
            if (name == null)
            {
                return NotFound();
            }

            return Ok(names);
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var name = _userRepository.GetUserByUsername(username);
            if (name == null)
            {
                return NotFound();
            }

            return Ok(await name);
        }
        [HttpGet]
        [Route("by-userId/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<User> GetUserByUserId(string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("upload-profile-picture")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var uploads = Path.Combine(_env.WebRootPath, "profile-pictures");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var filePath = Path.Combine(uploads, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            user.ProfilePicture = $"/profile-pictures/{file.FileName}";
            var updateResult = await _userRepository.UpdateUserAsync(user);
            if (!updateResult.Succeeded)
            {
                return BadRequest("Failed to update profile picture");
            }
            return Ok(new { FilePath = $"/profile-pictures/{file.FileName}" });

        }

        [HttpDelete]
        [Route("{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteUser(string username)
        {
            var result = await _userRepository.DeleteUserAsync(username);
            if (!result)
            {
                return NotFound("User not found");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userRepository.UpdateUserAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to update user");
            }
            return Ok(user);
        }
    }

}
