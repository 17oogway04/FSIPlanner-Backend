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
        private readonly IDisabilityInsRepository _disabilityRepository;
        public DisabilityInsController(ILogger<DisabilityInsController> logger, IDisabilityInsRepository repository)
        {
            _logger = logger;
            _disabilityRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<DisabilityInsurance>> GetAllDisabilities()
        {
            return Ok(_disabilityRepository.GetAllDisabilityIns());
        }

        [HttpGet]
        [Route("{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<DisabilityInsurance>>> GetDisabilityByUsername(string username)
        {
            IEnumerable<DisabilityInsurance> disabilities = (IEnumerable<DisabilityInsurance>) await _disabilityRepository.GetDisabilityInsByUsername(username);

            if(disabilities == null || !disabilities.Any())
            {
                return NotFound();
            }

            return Ok(disabilities);
        }

        [HttpGet]
        [Route("{disabilityId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> GetDisabilityById(int disabilityId)
        {
            var disability = _disabilityRepository.GetDisabilityInsById(disabilityId);
            if(disability == null)
            {
                return NotFound();
            }
            return Ok(disability);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> CreateDisability(DisabilityInsurance disability)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            disability.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var newDisability = _disabilityRepository.CreateDisabilityIns(disability);
            return Created(nameof(GetDisabilityById), newDisability);
        }

        [HttpPut]
        [Route("{disabilityId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<DisabilityInsurance> UpdateDisability(DisabilityInsurance disability)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_disabilityRepository.UpdateDisabilityIns(disability));
        }

        [HttpDelete]
        [Route("{disabilityId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteDisability(int disabilityId)
        {
            _disabilityRepository.DeleteDisabilityIns(disabilityId);
            return NoContent();
        }
    }
}

