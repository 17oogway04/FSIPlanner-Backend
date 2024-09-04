using System.Security.Claims;
using fsiplanner_backend.Models;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _userRepository = repository;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Policy = "UsernamePolicy")]
        public ActionResult CreateUser(User user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _userRepository.CreateUser(user);
            return NoContent();
        }

        [HttpGet]
        [Route("login")]
        public ActionResult<string> SignIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest();
            }

            var token = _userRepository.SignIn(username, password);

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

            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            User currentUser = _userRepository.GetUserById(id);

            return Ok(currentUser);
        }


        [HttpGet]
        [Authorize(Policy = "UsernamePolicy")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("{name}")]
        [Authorize(Policy = "UsernamePolicy")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public ActionResult<User> GetUserByUserId(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }

}
