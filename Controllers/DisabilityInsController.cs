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
    public class DisabilityInsController : ControllerBase
    {
        private readonly ILogger<DisabilityInsController> _logger;
        private readonly IDisabilityInsRepository _disabilityInsRepository;

        public DisabilityInsController(ILogger<DisabilityInsController> logger, IDisabilityInsRepository repository)
        {
            _logger = logger;
            _disabilityInsRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<DisabilityInsurance>> GetDisabilityIns()
        {
            return Ok(_disabilityInsRepository.GetAllDisabilityIns());
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<DisabilityInsurance>>> GetDisabilityByUsername(string username)
        {
            IEnumerable<DisabilityInsurance> disability = (IEnumerable<DisabilityInsurance>) await _disabilityInsRepository.GetDisabilityInsByUsername(username);
            if(disability == null || !disability.Any())
            {
                return NotFound();
            }
            return Ok(disability);
        }

        [HttpGet]
        [Route("by-userId{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<DisabilityInsurance>>> GetDisabilityByUserId(string userId)
        {
            IEnumerable<DisabilityInsurance> disability = (IEnumerable<DisabilityInsurance>) await _disabilityInsRepository.GetDisabilityInsByUserId(userId);
            if(disability == null || !disability.Any())
            {
                return NotFound();
            }
            return Ok(disability);
        }

        [HttpGet]
        [Route("by-disabilityId{disabilityId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> GetDisabilityById(int disabilityId)
        {
            var disability = _disabilityInsRepository.GetDisabilityInsById(disabilityId);
            if(disability == null)
            {
                return NotFound();
            }
            return Ok(disability);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> CreateDisabilityIns(DisabilityInsurance disabilityInsurance)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            disabilityInsurance.UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var newDisabilityIns = _disabilityInsRepository.CreateDisabilityIns(disabilityInsurance);
            return Created(nameof(GetDisabilityById), newDisabilityIns);
        }

        [HttpPut]
        [Route("{disabilityInsId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> UpdateDisabilityIns(DisabilityInsurance disabilityInsurance)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_disabilityInsRepository.UpdateDisabilityIns(disabilityInsurance));
        }

        [HttpDelete]
        [Route("{disabilityInsId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteDisabilityIns(int disabilityInsId)
        {
            _disabilityInsRepository.DeleteDisabilityIns(disabilityInsId);
            return NoContent();
        }

    }
}