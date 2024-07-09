using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    //private readonly IUserRepository _userRepository;
}

}
