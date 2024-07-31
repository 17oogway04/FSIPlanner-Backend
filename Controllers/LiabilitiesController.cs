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
    public class LiabilitiesController : ControllerBase
    {
        private readonly ILogger<LiabilitiesController> _logger;
        private readonly ILiabilityRepository _liabilityRepository;
        public LiabilitiesController(ILogger<LiabilitiesController> logger, ILiabilityRepository repository)
        {
            _logger = logger;
            _liabilityRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Liabilities>> GetAllLiabilities()
        {
            return Ok(_liabilityRepository.GetAllLiabilites());
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Liabilities>>> GetLiabilityByUsername(string username)
        {
            IEnumerable<Liabilities> liability = (IEnumerable<Liabilities>) await _liabilityRepository.GetLiabilitiesByUsername(username);
            if(liability == null || !liability.Any())
            {
                return NotFound();
            }

            return Ok(liability);
        }

        [HttpGet]
        [Route("by-userId{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Liabilities>>> GetLiabilityByUserId(int userId)
        {
            IEnumerable<Liabilities> liability = (IEnumerable<Liabilities>) await _liabilityRepository.GetLiabilitiesByUserId(userId);
            if(liability == null || !liability.Any())
            {
                return NotFound();
            }
            return Ok(liability);
        }

        [HttpGet]
        [Route("by-liabilityId{liabilityId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Liabilities> GetLiabilityById(int liabilityId)
        {
            var liability = _liabilityRepository.GetLiabilitiesById(liabilityId);
            if(liability == null)
            {
                return NotFound();
            }
            return Ok(liability);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Liabilities> CreateLiability(Liabilities liabilities)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            liabilities.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var newLiability = _liabilityRepository.CreateLiability(liabilities);
            return Created(nameof(GetLiabilityById), newLiability);
        }

        [HttpPut]
        [Route("{liabilityId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Liabilities> UpdateLiability(Liabilities liabilities)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_liabilityRepository.UpdateLiability(liabilities));
        }

        [HttpDelete]
        [Route("{liabilityId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteLiability(int liabilityId)
        {
            _liabilityRepository.DeleteLiability(liabilityId);
            return NoContent();
        }

    }
}