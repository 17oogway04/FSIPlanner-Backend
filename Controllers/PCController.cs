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
    public class PCController : ControllerBase
    {
        private readonly ILogger<PCController> _logger;
        private readonly IPCRepository _pcRepository;
        public PCController(ILogger<PCController> logger, IPCRepository repository)
        {
            _logger = logger;
            _pcRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<DisabilityInsurance>> GetAllPC()
        {
            return Ok(_pcRepository.GetAllPC());
        }

        [HttpGet]
        [Route("{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PC>>> GetPCByUsername(string username)
        {
            IEnumerable<PC> pc = (IEnumerable<PC>) await _pcRepository.GetPCByUsername(username);
            if(pc == null || !pc.Any())
            {
                return NotFound();
            }

            return Ok(pc);
        }

        [HttpGet]
        [Route("{pcId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<PC> GetPCById(int pcId)
        {
            var pc = _pcRepository.GetPCById(pcId);
            if(pc == null)
            {
                return NotFound();
            }
            return Ok(pc);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<PC> CreatePC(PC pc)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            pc.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var newPC = _pcRepository.CreatePC(pc);
            return Created(nameof(GetPCById), newPC);
        }

        [HttpPut]
        [Route("{pcId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<PC> UpdatePC(PC pc)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_pcRepository.UpdatePC(pc));
        }

        [HttpDelete]
        [Route("{pcId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeletePC(int pcId)
        {
            _pcRepository.DeletePC(pcId);
            return NoContent();
        }
    }
}