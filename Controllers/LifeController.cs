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
    public class LifeController : ControllerBase
    {
        private readonly ILogger<LifeController> _logger;
        private readonly ILifeRepository _lifeRepository;
        public LifeController(ILogger<LifeController> logger, ILifeRepository repository)
        {
            _logger = logger;
            _lifeRepository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Life>> GetAllLife()
        {
            return Ok(_lifeRepository.GetAllLife());
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Life>>> GetLifeByUsername(string username)
        {
            IEnumerable<Life> life = (IEnumerable<Life>) await _lifeRepository.GetLifeByUsername(username);

            if(life == null || !life.Any())
            {
                return NotFound();
            }

            return Ok(life);
        }

        [HttpGet]
        [Route("by-userId{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Life>>> GetLifeByUserId(int userId)
        {
            IEnumerable<Life> life = (IEnumerable<Life>) await _lifeRepository.GetLifeByUserId(userId);
            if(life == null || !life.Any())
            {
                return NotFound();
            }
            return Ok(life);
        }

        [HttpGet]
        [Route("by-lifeId{lifeId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Life> GetLifeById(int lifeId)
        {
            var life = _lifeRepository.GetLifeById(lifeId);
            if(life == null)
            {
                return NotFound();
            }

            return Ok(life);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Life> CreateLife(Life life)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            life.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            
            var newLife = _lifeRepository.CreateLife(life);
            return Created(nameof(GetLifeById), newLife);
        }

        [HttpPut]
        [Route("{lifeId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Life> UpdateLife(Life life)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_lifeRepository.UpdateLife(life));
        }

        [HttpDelete]
        [Route("{lifeId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteLife(int lifeId)
        {
            _lifeRepository.DeleteLife(lifeId);
            return NoContent();
        }

    }
}