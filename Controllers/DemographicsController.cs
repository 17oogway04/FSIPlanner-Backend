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

    public class DemographicsController : ControllerBase
    {
        private readonly ILogger<DemographicsController> _logger;
        private readonly IDemographicsRepository _demographicsRepository;

        public DemographicsController(ILogger<DemographicsController> logger, IDemographicsRepository repository)
        {
            _logger = logger;
            _demographicsRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Demographics>> GetDemographics()
        {
            return Ok(_demographicsRepository.GetAllDemographics());
        }

        [HttpGet]
        [Route("{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Demographics>>> GetDemographicsByUsername(string username)
        {
            IEnumerable<Demographics> demographics = (IEnumerable<Demographics>) await _demographicsRepository.GetDemographicsByUsername(username);
            if(demographics == null || !demographics.Any())
            {
                return NotFound();
            }

            return Ok(demographics);
        }

        [HttpGet]
        [Route("{demographicId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Demographics> GetDemographicsById(int demographicId)
        {
            var demographic = _demographicsRepository.GetDemographic(demographicId);
            if(demographic == null)
            {
                return NotFound();
            }
            return Ok(demographic);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Demographics> CreateDemographic(Demographics demographics)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            demographics.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var newDemographic = _demographicsRepository.CreateDemographics(demographics);
            return Created(nameof(GetDemographicsById), newDemographic);
        }

        [HttpPut]
        [Route("{demographicId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Demographics> UpdateDemographic(Demographics demographics)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_demographicsRepository.UpdateDemographic(demographics));
        }

        [HttpDelete]
        [Route("{demographicId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteDemographic(int demographicId)
        {
            _demographicsRepository.DeleteDemographic(demographicId);
            return NoContent();
        }

    }
}